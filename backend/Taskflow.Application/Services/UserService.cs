using AutoMapper;
using Taskflow.Application.DTO.User;
using Taskflow.Application.Interfaces.Repositories;
using Taskflow.Application.Interfaces.Services;
using Taskflow.Application.Response;
using Taskflow.Domain.Entities;

namespace Taskflow.Application.Services;

public class UserService: IUserService
{
    private readonly IUserRepository repository;
    private readonly IMapper mapper;
    private readonly IFileService fileService;
    
    public UserService(IUserRepository repository,
        IFileService fileService,
        IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.fileService = fileService;
    }
    
    public async Task<Result<Guid>> Update(UserUpdateDTO model)
    {
        var entity =  mapper.Map<UserEntity>(model);
        

        if (model.Image != null)
        {
            var fileResult = await fileService.UpdateImage(model.FileId, model.Image, entity.Id);

            if (!fileResult.IsSuccess)
            {
                return fileResult;
            }
            
            entity.FileId = fileResult.Data;
        }
        
        Guid id = await repository.Update(entity);

        return Result<Guid>.Success(id);
    }

    public async Task<Result<UserGetDTO>> Get(Guid id)
    {
        UserEntity entity = await repository.GetUser(id);

        var result = mapper.Map<UserGetDTO>(entity);
        return Result<UserGetDTO>.Success(result);
    }
}