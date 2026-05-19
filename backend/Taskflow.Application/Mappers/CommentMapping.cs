using AutoMapper;
using Taskflow.Application.DTO.Comments;
using Taskflow.Domain.Entities;

namespace Taskflow.Application.Mappers;

public class CommentMapping: Profile
{
    public CommentMapping()
    {
        CreateMap<CommentUpdateDTO,CommentEntity>()
            .ForMember(destination=>destination.FileId,opt=>opt.MapFrom(comment=>comment.FileId))
            .ForMember(entity=>entity.Content,opt=>opt.MapFrom(comment=>comment.Content))
            .ForMember(entity=>entity.Id ,opt=>opt.MapFrom(comment=>comment.Id));
        
        CreateMap<CommentEntity,CommentGetDTO>()
            .ForMember(model=>model.Content,opt=>opt.MapFrom(comment=>comment.Content))
            .ForMember(model=>model.Id,opt=>opt.MapFrom(comment=>comment.Id))
            .ForMember(model=>model.FileId,opt=>opt.MapFrom(comment=>comment.FileId))
            .ForMember(model=>model.FirstName, option=>option.MapFrom(comment=>comment.User.FirstName))
            .ForMember(model=>model.LastName, option=>option.MapFrom(comment=>comment.User.LastName))
            .ForMember(model=>model.UserId, option=>option.MapFrom(comment=>comment.CreatedBy))
            .ForMember(model=>model.Created, option=>option.MapFrom(comment=>comment.CreatedAt))
            .ForMember(model=>model.Updated, option=>option.MapFrom(comment=>comment.UpdatedAt));
        
            
    }
}