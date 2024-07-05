namespace FavouriteAPI.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? JobTitle { get; set; }
        public string? JobDescription { get; set; }
        public string? JobLocation { get; set; }
        public string? Category { get; set; }
        public decimal Salary { get; set; }
        public bool IsBlocked { get; set; }
    }
}
