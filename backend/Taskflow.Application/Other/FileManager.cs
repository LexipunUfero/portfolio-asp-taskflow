using Microsoft.Extensions.Options;
using Taskflow.Application.Validators;

namespace Taskflow.Application.IO;

public class FileManager
{
    private readonly FileConfigs configs;
    public FileManager(IOptions<FileConfigs> configs)
    {
        this.configs = configs.Value;
    }
    public bool ValidateImage(IFormFile file)
    {
        var extension = Path.GetExtension(file.FileName).ToLower();

        if (!configs.ImageExtensions.Contains(extension))
        {
            return false;
        }
        
        return true;
    }
    
    public string Write(IFormFile file, Guid? userId)
    {
        
        Directory.CreateDirectory(configs.Folder);
        Guid name = Guid.NewGuid();
        var fileName = string.Format("{0}_{1}", userId.ToString(), name);
        
        using StreamWriter writer = new(Path.Combine( configs.Folder, fileName));
        writer.Write(file.OpenReadStream());
        return fileName;
    }
    
    public string Write(IFormFile file, string fileName)
    {
        
        Directory.CreateDirectory(configs.Folder);
        
        using StreamWriter writer = new(Path.Combine( configs.Folder, fileName));
        writer.Write(file.OpenReadStream());
        return fileName;
    }
}