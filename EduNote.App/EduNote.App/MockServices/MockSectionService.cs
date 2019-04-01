using EduNote.API.Shared.ApiModels;
using EduNote.App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduNote.App.MockServices
{
    public class MockSectionService : ISectionService
    {
        public Task<SectionDetailDTO> Get(long id)
        {
            List<SectionDetailDTO> result = new List<SectionDetailDTO>()
            {
                new SectionDetailDTO()
                {
                    Id = 1,
                    Title = "Year 1",
                    Description = "School year 1",
                    Sections = new List<SectionListDTO>()
                    {
                        new SectionListDTO()
                        {
                            Id = 3,
                            Title = "Dev",
                            Description = "Development classes",
                            ParentId = 1
                        }
                    },
                    Questions = new List<QuestionListDTO>()
                    {
                        new QuestionListDTO()
                        {
                            Id = 1,
                            Title = "Why is a camel?",
                            Body = "Confirmed to have a body.",
                            Created = DateTime.Now,
                            SectionId = 1,
                            CreatedById = 1
                        }
                    },
                    Notes = new List<NoteDTO>()
                },
                new SectionDetailDTO()
                {
                    Id = 2,
                    Title = "Year 2",
                    Description = "School year 2",
                    Sections = new List<SectionListDTO>(),
                    Questions = new List<QuestionListDTO>(),
                    Notes = new List<NoteDTO>()
                },
                new SectionDetailDTO()
                {
                    Id = 3,
                    Title = "Dev",
                    Description = "Development classes",
                    Sections = new List<SectionListDTO>(),
                    Questions = new List<QuestionListDTO>(),
                    Notes = new List<NoteDTO>()
                }
            };
            return Task.FromResult(result.Single(x => x.Id == id));
        }

        public Task<IEnumerable<SectionListDTO>> GetRoot()
        {
            List<SectionListDTO> result = new List<SectionListDTO>()
            {
                new SectionListDTO()
                {
                    Id = 1,
                    Title = "Year 1",
                    Description = "School year 1",
                },
                new SectionListDTO()
                {
                    Id = 2,
                    Title = "Year 2",
                    Description = "School year 2"
                }
            };
            return Task.FromResult(result.AsEnumerable());
        }
    }
}
