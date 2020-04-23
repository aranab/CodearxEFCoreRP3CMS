using CodearxEFCoreRP3CMS.Models.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CodearxEFCoreRP3CMS.Models
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Slug")]
        public string ID { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Post Content")]
        public string Content { get; set; }

        [Display(Name = "Date Created")]
        public DateTime Created { get; set; }

        [Display(Name = "Date Published")]
        public DateTime? Published { get; set; }        

        public string CombinedTags
        {
            get
            {
                return string.Join(",", Tags);
            }

            set
            {
                Tags = value.Split(',').Select(s => s.Trim()).ToList();
            }
        }

        [Required]
        public string AuthorID { get; set; }

        public CmsUser Author { get; set; }

        [NotMapped]
        [BindProperty(BinderType = typeof(PostModelBinder))]
        public IList<string> Tags { get; set; } = new List<string>();
    }
}
