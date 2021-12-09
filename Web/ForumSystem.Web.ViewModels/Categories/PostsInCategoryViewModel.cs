namespace ForumSystem.Web.ViewModels.Categories
{
    using System.Text.RegularExpressions;

    using ForumSystem.Data.Models;
    using ForumSystem.Services.Mapping;

    public class PostsInCategoryViewModel : IMapFrom<Post>
    {
        public string Title { get; set; }

        public string FixedTitle
        {
            get
            {
                var title = Regex.Replace(this.Title, @"<[^>]+>[&]*", string.Empty);
                return title.Length > 100 ? title.Substring(0, 100) + "..." : title;
            }
        }

        public string UserUsername { get; set; }

        public string Contnet { get; set; }

        public string FixedContent
        {
            get
            {
                var content = Regex.Replace(this.Contnet, @"<[^>]+>[&]*", string.Empty);
                return content.Length > 100 ? content.Substring(0, 100) + "..." : content;
            }
        }

        public int CommentsCount { get; set; }
    }
}
