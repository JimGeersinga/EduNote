using System.Collections.Generic;

namespace EduNote.API.Shared.ApiModels
{
    public class UserDetailDTO : UserListDTO
    {
        public List<GroupListDTO> Groups { get; set; } = new List<GroupListDTO>();
        public List<QuestionListDTO> Questions { get; set; } = new List<QuestionListDTO>();
        public List<AnswerDTO> Answers { get; set; } = new List<AnswerDTO>();
        public List<NoteDTO> Notes { get; set; } = new List<NoteDTO>();
    }
}