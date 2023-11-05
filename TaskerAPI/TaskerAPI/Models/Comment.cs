using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace TaskerAPI.Models
{
    public class Comment
    {
        [Key]
        [BindNever]
        public int Id { get; set; }
        public string Text { get; set; }
        public Person Author { get; set; } 
        public Task Task { get; set; } 
    }
}
