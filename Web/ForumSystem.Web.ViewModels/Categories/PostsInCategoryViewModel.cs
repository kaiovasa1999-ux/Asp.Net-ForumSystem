namespace ForumSystem.Web.ViewModels.Categories
{
    using ForumSystem.Data.Models;

    using ForumSystem.Services.Mapping;

    public class PostsInCategoryViewModel : IMapFrom<Post>
    {
        public string Title { get; set; }

        public string UserUsername { get; set; }

        public int CommentsCount { get; set; }
    }
}
