using AutoMapper;
using EduNote.API.EF.Models;
using EduNote.API.Shared.ApiModels;
namespace EduNote.API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Answer, AnswerAPIModel>().ReverseMap();
            CreateMap<Group, GroupAPIModel>().ReverseMap();
            CreateMap<Note, NoteAPIModel>().ReverseMap();
            CreateMap<NoteTags, NoteTagsAPIModel>().ReverseMap();
            CreateMap<Question, QuestionAPIModel>().ReverseMap();
            CreateMap<QuestionTags, QuestionTagAPIModel>().ReverseMap();
            CreateMap<Section, SectionAPIModel>().ReverseMap();
            CreateMap<Tag, TagAPIModel>().ReverseMap();
            CreateMap<User, UserAPIModel>().ReverseMap();
            CreateMap<UserGroups, UserGroupAPIModel>().ReverseMap();
        }
    }
}
