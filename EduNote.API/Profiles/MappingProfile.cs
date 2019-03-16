using AutoMapper;
using EduNote.API.EF.Models;
using EduNote.API.Shared.ApiModels;
namespace EduNote.API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Answer, AnswerDTO>().ReverseMap();
            CreateMap<Group, GroupDetailDTO>().ReverseMap();
            CreateMap<Group, GroupListDTO>().ReverseMap();
            CreateMap<Note, NoteDTO>().ReverseMap();
            CreateMap<Question, QuestionDetailDTO>().ReverseMap();
            CreateMap<Question, QuestionListDTO>().ReverseMap();
            CreateMap<Section, SectionDetailDTO>().ReverseMap();
            CreateMap<Section, SectionListDTO>().ReverseMap();
            CreateMap<Tag, TagDTO>().ReverseMap();
            CreateMap<User, UserDetailDTO>().ReverseMap();
            CreateMap<User, UserListDTO>().ReverseMap();
        }
    }
}
