namespace ForumSystem.Services.Data.CategoriesService
{
    using System.Collections;
    using System.Collections.Generic;

    using ForumSystem.Web.ViewModels.Categories;
    using ForumSystem.Web.ViewModels.Home;

    public interface ICategoryService
    {
        IEnumerable<IndexCategriesViewModel> GetAll();

        T GetByTitle<T>(string title);
    }
}
