using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace TaskerAPI.Models
{
    public class TaskStatus
    {
        [Key]
        [BindNever]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
