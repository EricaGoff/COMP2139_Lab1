using System.ComponentModel.DataAnnotations;

namespace COMP2139_Lab1.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }
        
        
        public int ProjectId { get; set; }
        
        public Project? Project { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}