namespace ForumSystem.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using ForumSystem.Data.Common.Models;
    using ForumSystem.Data.Models;
    using ForumSystem.Services.Mapping;

    public class IndexCategriesViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }
    }
}
