using Taskflow.Application.DTO.Project.Access;
using Taskflow.Application.DTO.User;

namespace Taskflow.Application.DTO.Project.Member;

public class MemberGetDTO
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid ImageId { get; set; }
    public ProjectAccessGetPreviewDTO Access { get; set; }
    public DateTime Added {get; set;}
}