namespace ForumSystem.Web.Controllers
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    using ForumSystem.Data.Common.Repositories;
    using ForumSystem.Data.Models;
    using ForumSystem.Services.Data.PostServices;
    using ForumSystem.Web.IdenityHellpMethod;
    using ForumSystem.Web.ViewModels.Post;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class PostsController : Controller
    {
        private readonly IPostService postService;

        public PostsController(IPostService postService)
        {
            this.postService = postService;
        }

        public IActionResult PostById(int id)
        {
            return this.View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddPost()
        {
            var viewModel = new PostViewModel();
            viewModel.Categories = this.postService.GetCategoryTitles<CategoryDropDown>();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPost(PostViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var userid = this.User.GetUserId();
            input.Categories = this.postService.GetCategoryTitles<CategoryDropDown>();
            var postId = await this.postService.AddPostAsync(input);

            return this.RedirectToAction("PostById", new { id = postId });
        }
    }
}
