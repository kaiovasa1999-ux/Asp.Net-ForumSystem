namespace ForumSystem.Web.ViewModels.Home
{
    using AutoMapper;
    using ForumSystem.Data.Models;
    using ForumSystem.Services.Mapping;

    public class IndexCategriesViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public int PostsCount { get; set; }
    }
}
