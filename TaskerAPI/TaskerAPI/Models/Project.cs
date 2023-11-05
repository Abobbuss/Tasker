using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace TaskerAPI.Models
{
    public class Project
    {
        [Key]
        [BindNever]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public Person Creator { get; set; }
        public string? Status { get; set; }
        public DateTime? EndDate { get; set; }

        public Project()
        {
            StartDate = DateTime.UtcNow; 
        }
    }
}
