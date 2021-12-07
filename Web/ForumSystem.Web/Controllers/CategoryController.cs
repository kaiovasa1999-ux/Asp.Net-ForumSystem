namespace ForumSystem.Web.Controllers
{
    using ForumSystem.Services.Data.CategoriesService;
    using ForumSystem.Web.ViewModels.Category;
    using Microsoft.AspNetCore.Mvc;

    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult ByTitle(string title)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var viewModel = new CategoryViewModel();

            return this.View(viewModel);
        }
    }
}
