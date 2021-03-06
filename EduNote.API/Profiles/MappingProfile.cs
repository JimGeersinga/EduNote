﻿using AutoMapper;
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
            CreateMap<Note, NoteDTO>().ForMember(
                    dest => dest.CreatorName, opt => opt.MapFrom(src => src.CreatedBy.FirstName + " " + src.CreatedBy.LastName)
                ).ReverseMap(); ;
            CreateMap<Question, QuestionDetailDTO>().ForMember(
                    dest => dest.CreatorName, opt => opt.MapFrom(src => src.CreatedBy.FirstName + " " + src.CreatedBy.LastName)
                ).ReverseMap();
            CreateMap<Question, QuestionListDTO>().ForMember(
                    dest=> dest.CreatorName, opt => opt.MapFrom(src=>src.CreatedBy.FirstName + " " + src.CreatedBy.LastName)
                ).ReverseMap();
            CreateMap<Section, SectionDetailDTO>().ReverseMap();
            CreateMap<Section, SectionListDTO>().ReverseMap();
            CreateMap<Tag, TagDTO>().ReverseMap();
            CreateMap<User, UserDetailDTO>()
                .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.QuestionsCreated))
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.NotesCreated))
                .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.AnswersCreated))
                .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.UserGroups))
                .ReverseMap();
            CreateMap<User, UserListDTO>().ReverseMap();
            CreateMap<RegisterDTO, User>().ForMember(x => x.Password, opt => opt.Ignore());
        }
    }
}
