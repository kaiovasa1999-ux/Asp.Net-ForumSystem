using ForumSystem.Web.ViewModels.Home;

namespace ForumSystem.Services.Data.CategoriesService
{
    public interface ICategoryService
    {
        CategriesviewModel FindByTitle(string title);
    }
}
