using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodearxEFCoreRP3CMS.Models
{
    public class Post
    {
        [Display(Name = "Slug")]
        public string ID { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Post Content")]
        public string Content { get; set; }

        [Display(Name = "Date Created")]
        public DateTime Created { get; set; }

        [Display(Name = "Date Published")]
        public DateTime? Published { get; set; }


        public int AuthorID { get; set; }
    }
}
