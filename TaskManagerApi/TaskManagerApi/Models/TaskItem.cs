using System.ComponentModel.DataAnnotations;

namespace TaskManagerApi.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        
        public required string Title { get; set; }

        public required string Description { get; set; }
    }
}