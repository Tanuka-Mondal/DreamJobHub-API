using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FavouriteAPI.Models
{
    public class Favourite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public int JobId { get; set; }
        public string? JobTitle { get; set; }
        public string? JobCategory { get; set; }
        public string? Company {  get; set; }
    }
}
