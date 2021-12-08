namespace ForumSystem.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using ForumSystem.Data.Models;
    using ForumSystem.Services.Mapping;

    public class IndexPageModel : IMapFrom<Category>
    {
        public IEnumerable<IndexCategriesViewModel> Categoreis { get; set; }
    }
}
