using System;
using System.ComponentModel.DataAnnotations;

namespace Mission4.Models
{
    public class movieTemplate
    {
        [Key]
        [Required]
        public int MovieID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; } 
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
