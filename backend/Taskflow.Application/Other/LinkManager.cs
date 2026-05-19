using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Taskflow.Domain.Models.Configs;
using Taskflow.Domain.Models.DAO;

namespace Taskflow.Application.Validators;

public class LinkManager
{
    private readonly IMemoryCache cache;
    private readonly LinkConfigs configs;
    
    public LinkManager(IMemoryCache memoryCache,
        IOptions<LinkConfigs> congigs)
    {
        this.configs = congigs.Value;
        cache = memoryCache;
    }
    
    public string CreateInvite(ProjectMemberDAO model, float time)
    {
        var key =  Guid.NewGuid().ToString();
        cache.Set(configs.ProjectInvitePrefix + key, model,DateTimeOffset.Now.AddMinutes(time));

        return key;
    }
    public bool VerifyInvite(string id)
    {
        return cache.TryGetValue(configs.ProjectInvitePrefix + id, out _);
    }
    
    public ProjectMemberDAO Get(string id)
    {
        return cache.Get<ProjectMemberDAO>(configs.ProjectInvitePrefix + id);
    }
}