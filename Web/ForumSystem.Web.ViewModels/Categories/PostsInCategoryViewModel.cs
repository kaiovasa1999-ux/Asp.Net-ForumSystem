namespace ForumSystem.Web.ViewModels.Categories
{
    using System.Net;
    using System.Text.RegularExpressions;

    using ForumSystem.Data.Models;
    using ForumSystem.Services.Mapping;

    public class PostsInCategoryViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string FixedTitle
        {
            get
            {
                var title = WebUtility.HtmlDecode(Regex.Replace(this.Title, @"<[^>]+>[&]*", string.Empty));
                return title.Length > 200 ? title.Substring(0, 200) + "..." : title;
            }
        }

        public string UserUsername { get; set; }

        public string Contnet { get; set; }

        public string FixedContent
        {
            get
            {
                var content = WebUtility.HtmlDecode(Regex.Replace(this.Contnet, @"<[^>]+>[&]*", string.Empty));
                return content.Length > 200 ? content.Substring(0, 200) + "..." : content;
            }
        }

        public int CommentsCount { get; set; }
    }
}
