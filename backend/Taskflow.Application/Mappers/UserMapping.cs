using AutoMapper;
using Taskflow.Application.DTO.Autentication;
using Taskflow.Application.DTO.User;
using Taskflow.Domain.Entities;

namespace Taskflow.Application.Mappers;

public class UserMapping: Profile
{
    public UserMapping()
    {
        CreateMap<RegisterDTO, UserEntity>()
            .ForMember(entity => entity.FirstName,
                option => option.MapFrom(user => user.FirstName))
            .ForMember(entity => entity.LastName,
                option => option.MapFrom(user => user.LastName));
        
        CreateMap<UserUpdateDTO, UserEntity>()
            .ForMember(destination=>destination.FileId,opt=>opt.MapFrom(comment=>comment.FileId))
            .ForMember(entity => entity.FirstName,option=>option.MapFrom(user => user.FirstName))
            .ForMember(entity => entity.LastName,option=>option.MapFrom(user => user.LastName))
            .ForMember(destination=>destination.Id,option=>option.MapFrom(user => user.Id));

        CreateMap<UserEntity, UserGetDTO>()
            .ForMember(entity => entity.FirstName, option => option.MapFrom(user => user.FirstName))
            .ForMember(entity => entity.LastName, option => option.MapFrom(user => user.LastName))
            .ForMember(destination => destination.Id, option => option.MapFrom(user => user.Id))
            .ForMember(destination => destination.ImageId, option => option.MapFrom(source => source.FileId));
    }
}