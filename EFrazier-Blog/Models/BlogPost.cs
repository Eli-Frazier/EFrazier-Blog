using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EFrazier_Blog.Models
{
    public class BlogPost
    {
        //List out properties (or members)
        public int Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; } //this is a small teaser type thing 
        public string Slug { get; set; }

        [AllowHtml]
        public string Body { get; set; }

        public string MediaURL { get; set; }
        public bool Published { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public BlogPost()
        {
            Comments = new HashSet<Comment>();
        }
    }
}