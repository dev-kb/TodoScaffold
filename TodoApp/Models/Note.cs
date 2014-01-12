namespace TodoApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Note
    {
        [Key]
        public int NoteId { get; set; }
        public string Description { get; set; }
        public int? TaskId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}