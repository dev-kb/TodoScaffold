namespace TodoApp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        public string Name { get; set; }
    }
}