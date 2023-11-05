using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace TaskerAPI.Models
{
    public class Task
    {
        [Key]
        [BindNever]
        public int Id { get; set; }
        public string Description { get; set; }
        public string? TaskStatus { get; set; }
        public Person Performer { get; set; } 
        public Project Project { get; set; } 
    }
}
