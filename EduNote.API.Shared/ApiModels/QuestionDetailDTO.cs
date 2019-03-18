using System;
using System.Collections.Generic;

namespace EduNote.API.Shared.ApiModels
{
    public class QuestionDetailDTO : QuestionListDTO
    {
        public List<AnswerDTO> Answers { get; set; } = new List<AnswerDTO>();
    }
}