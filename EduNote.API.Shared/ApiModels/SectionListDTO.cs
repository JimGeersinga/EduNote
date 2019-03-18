namespace EduNote.API.Shared.ApiModels
{
    public class SectionListDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int? ParentId { get; set; }
    }
}