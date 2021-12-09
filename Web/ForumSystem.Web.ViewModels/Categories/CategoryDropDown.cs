namespace ForumSystem.Web.ViewModels.Post
{
    using ForumSystem.Data.Models;
    using ForumSystem.Services.Mapping;

    public class CategoryDropDown : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
