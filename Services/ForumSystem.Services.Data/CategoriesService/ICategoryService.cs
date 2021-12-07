namespace ForumSystem.Services.Data.CategoriesService
{
    using System.Collections;
    using System.Collections.Generic;

    using ForumSystem.Web.ViewModels.Home;

    public interface ICategoryService
    {
        IndexCategriesViewModel FindByTitle(string title);

        IEnumerable<T> GetAll<T>(int? count = null);
    }
}
