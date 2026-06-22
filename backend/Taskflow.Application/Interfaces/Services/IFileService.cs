using Microsoft.AspNetCore.Mvc;
using Taskflow.Application.Response;

namespace Taskflow.Application.Interfaces.Services;

public interface IFileService
{
    public Task<Result<FileStreamResult>> Get(Guid id);
    public Task<Result<Guid>> SaveImage(IFormFile image, Guid? userId = null);
    public Task<Result<Guid>> UpdateImage(Guid? fileId, IFormFile image, Guid userId);
}