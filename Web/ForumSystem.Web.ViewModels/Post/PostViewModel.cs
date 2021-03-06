namespace ForumSystem.Web.ViewModels.Post
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Net;
    using System.Text.RegularExpressions;

    using ForumSystem.Data.Models;
    using ForumSystem.Services.Mapping;
    using Ganss.XSS;

    public class PostViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string SanitizedTitle => new HtmlSanitizer().Sanitize(this.Title);

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Contnet);

        public string UserUserName { get; set; }

        [Required]
        [Display(Name = "Category")]

        public int CategoryId { get; set; }

        public IEnumerable<CategoryDropDown> Categories { get; set; }

        public string UserId { get; set; }

        [Required]
        [StringLength(maximumLength: 2500, ErrorMessage = "The length of the message couldn't be more then 2500 simbols")]
        public string Contnet { get; set; }
    }
}
