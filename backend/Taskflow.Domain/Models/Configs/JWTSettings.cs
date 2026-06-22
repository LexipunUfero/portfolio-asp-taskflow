namespace Taskflow.Domain.Models.Configs;

public class JWTSettings
{
    public string Key { get; set; }
    public int ExpireTime { get; set; }
}