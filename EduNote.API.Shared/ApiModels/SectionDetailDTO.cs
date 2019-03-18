using System.Collections.Generic;

namespace EduNote.API.Shared.ApiModels
{
    public class SectionDetailDTO : SectionListDTO
    {
        public List<SectionListDTO> Sections { get; set; } = new List<SectionListDTO>();
        public List<QuestionListDTO> Questions { get; set; } = new List<QuestionListDTO>();
        public List<NoteDTO> Notes { get; set; } = new List<NoteDTO>();
    }
}