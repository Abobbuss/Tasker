using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace TaskerAPI.Models
{
    public class PersonProject
    {
        [Key]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        [Key]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
