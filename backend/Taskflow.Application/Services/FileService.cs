using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Taskflow.Application.Interfaces.Repositories;
using Taskflow.Application.Interfaces.Services;
using Taskflow.Application.IO;
using Taskflow.Application.Response;
using Taskflow.Domain.Entities;
using Taskflow.Domain.Models.Configs;

namespace Taskflow.Application.Service;

public class FileService : IFileService
{
    private readonly IFileRepository repository;
    private readonly FileManager fileManager;
    private readonly ErrorMessages errorMessages;
    private readonly ILogger<FileService> logger;

    public FileService(
        IFileRepository repository,
        FileManager fileManager,
        IOptions<ErrorMessages> errorMessages,
        ILogger<FileService> logger)
    {
        this.fileManager = fileManager;
        this.repository = repository;
        this.errorMessages = errorMessages.Value;
        this.logger = logger;
    }

    public async Task<Result<FileStreamResult>> Get(Guid id)
    {
        try
        {
            var fileEntity = await repository.Get(id);

            using (var stream = new StreamReader(fileEntity.FileName))
            {
                return Result<FileStreamResult>.Success(new FileStreamResult(stream.BaseStream, "image/png"));
            }
        }
        catch (Exception e)
        {
            return Result<FileStreamResult>.Fail(e.Message);
        }
    }

    public async Task<Result<Guid>> SaveImage(IFormFile image, Guid? userId)
    {
        if (!fileManager.ValidateImage(image))
        {
            logger.LogInformation("Incorrect file format");
            return Result<Guid>.Fail(errorMessages.InvalidImage);
        }

        var fileName = fileManager.Write(image, userId);

        var fileId = await repository.Create(image, fileName, userId);

        return Result<Guid>.Success(fileId);
    }

    public async Task<Result<Guid>> UpdateImage(Guid? fileId, IFormFile image, Guid userId)
    {
        if (fileId == null)
        {
            return await SaveImage(image, userId);
        }

        if (!fileManager.ValidateImage(image))
        {
            logger.LogInformation("Incorrect file format");
            return Result<Guid>.Fail(errorMessages.InvalidImage);
        }

        FileEntity entity = await repository.Get(fileId.Value);
        fileManager.Write(image, entity.FileName);

        return Result<Guid>.Success(entity.Id);
    }
}