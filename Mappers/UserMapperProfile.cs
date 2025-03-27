using AutoMapper;
using LearningVocab.DTO;
using LearningVocab.Models;

namespace LearningVocab.Mappers
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<User, CreateUserModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}
