namespace PeopleManager.API.DTO
{
    public class CreateJobRequest
    {
        public Guid PersonId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } // Nullable pour les emplois en cours
    }
}
