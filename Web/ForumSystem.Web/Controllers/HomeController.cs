namespace ForumSystem.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using ForumSystem.Data;
    using ForumSystem.Services.Data.CategoriesService;
    using ForumSystem.Web.ViewModels;
    using ForumSystem.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext data;
        private readonly ICategoryService categoryService;

        public HomeController(ApplicationDbContext data,ICategoryService categoryService)
        {
            this.data = data;
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexPageModel();
            var categories = this.categoryService.GetAll<IndexCategriesViewModel>();
            viewModel.Categoreis = categories;
            return this.View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
