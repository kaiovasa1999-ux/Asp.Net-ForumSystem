namespace ForumSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using ForumSystem.Services.Data.CategoriesService;
    using ForumSystem.Web.ViewModels.Categories;
    using ForumSystem.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult ByTitle(string title)
        {
            var viewModel = this.categoryService.FindByTitle(title);
            return this.View(viewModel);
        }
    }
}
