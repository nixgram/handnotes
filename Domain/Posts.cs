using System;
using System.ComponentModel.DataAnnotations;

namespace handnotes.Domain
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
    

    }
}