using AutoMapper;
using Taskflow.Application.DTO.Markdown;
using Taskflow.Domain.Entities;

namespace Taskflow.Application.Mappers;

public class MarkdownMapping:Profile
{
    public MarkdownMapping()
    {
        CreateMap<MarkdownCreateDTO, MarkdownEntity>()
            .ForMember(entity => entity.Name, option => option.MapFrom(model => model.Title))
            .ForMember(entity => entity.Color, option => option.MapFrom(model => model.Color))
            .ForMember(entity => entity.ProjectId, option => option.MapFrom(model => model.ProjectId));

        CreateMap<MarkdownUpdateDTO, MarkdownEntity>()
            .ForMember(entity => entity.Id, option => option.MapFrom(model => model.Id))
            .ForMember(entity => entity.Name, option => option.MapFrom(model => model.Title))
            .ForMember(entity => entity.Color, option => option.MapFrom(model => model.Color));

        CreateMap<MarkdownEntity, MarkdownGetDTO>()
            .ForMember(entity => entity.Id, option => option.MapFrom(model => model.Id))
            .ForMember(model => model.Color, option => option.MapFrom(model => model.Color))
            .ForMember(model => model.Title, option => option.MapFrom(entity => entity.Name));
        
    }
}