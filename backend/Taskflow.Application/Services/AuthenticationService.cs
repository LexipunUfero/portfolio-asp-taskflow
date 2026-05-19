using AutoMapper;
using Microsoft.Extensions.Options;
using Taskflow.Application.DTO.Autentication;
using Taskflow.Application.DTO.User;
using Taskflow.Application.Interfaces.Repositories;
using Taskflow.Application.Interfaces.Services;
using Taskflow.Application.Response;
using Taskflow.Application.Validators;
using Taskflow.Domain.Entities;
using Taskflow.Domain.Models.Configs;

namespace Taskflow.Application.Service;

public class AuthenticationService: IAuthenticationService
{
    private readonly JwtGenerator jwtGenerator;
    private readonly IUserRepository repository;
    private readonly ErrorMessages errorMessages;
    private readonly IMapper mapper;
    private readonly HashManager hashManager;
    private readonly IFileService fileService;
    private readonly ILogger<AuthenticationService> logger;
    
    public AuthenticationService(JwtGenerator jwtGenerator,
        HashManager hashManager,
        IUserRepository repository,
        IOptions<ErrorMessages> errorMessages,
        IFileService fileService,
        IMapper mapper,
        ILogger<AuthenticationService> logger)
    {
        this.jwtGenerator = jwtGenerator;
        this.repository = repository;
        this.errorMessages = errorMessages.Value;
        this.mapper = mapper;
        this.hashManager = hashManager;
        this.fileService = fileService;
        this.logger = logger;
    }
    
    public async Task<Result<string>> Login(LoginDTO model)
    {
        UserPasswordEntity? user = await repository.Get(model.Login);
        
        if (user is null)
        {
            logger.LogInformation("User not found");
            return Result<string>.Fail(errorMessages.InvalidLogin);
        }

        if (hashManager.VerifyPassword(model.Password, user.Password))
        {
            var token = jwtGenerator.GetToken(user.UserId);
            return Result<string>.Success(token);
        }
        
        logger.LogInformation("User not found");
        return Result<string>.Fail(errorMessages.InvalidLogin);
    }
    
    public async Task<Result<Guid>> Create(RegisterDTO model)
    {
        var entity =  mapper.Map<UserEntity>(model);

        if (model.Image != null)
        {
            var fileResult = await fileService.SaveImage(model.Image);

            if (!fileResult.IsSuccess)
            {
                return fileResult;
            }

            entity.FileId = fileResult.Data;
        }
        
        var passwordEntity = new UserPasswordEntity
        {
            Salt = hashManager.GenerateSalt(),
        };
        passwordEntity.Password = hashManager.HashPassword(model.Password, passwordEntity.Salt);
        
        Guid id = await repository.Create(entity, passwordEntity);
        
        
        
        return Result<Guid>.Success(id);
    }
    
    
    public async Task<Result<Guid>> Update(UserPasswordUpdateDTO model, Guid userId)
    {
        UserPasswordEntity user = await repository.Get(userId);
        

        if (!hashManager.VerifyPassword(model.OldPassword, user.Password))
        {
            logger.LogInformation("Incorrect password");
            return Result<Guid>.Fail(errorMessages.InvalidPassword);
        }
        
        user.Password = hashManager.HashPassword(model.NewPassword, user.Salt);
        
        return Result<Guid>.Success(user.UserId);
    }
}