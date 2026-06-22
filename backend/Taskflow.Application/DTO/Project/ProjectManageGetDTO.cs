using Taskflow.Application.DTO.Project.Member;
using Taskflow.Application.DTO.User;

namespace Taskflow.Application.DTO.Project;

public class ProjectManageGetDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<MemberGetDTO> Members { get; set; }
}