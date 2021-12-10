namespace ForumSystem.Web.Controllers
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    using ForumSystem.Data.Common.Repositories;
    using ForumSystem.Data.Models;
    using ForumSystem.Services.Data.PostServices;
    using ForumSystem.Web.IdenityHellpMethod;
    using ForumSystem.Web.ViewModels.Categories;
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
            var viewModel = this.postService.GetById<PostsInCategoryViewModel>(id);
            return this.View(viewModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddPost()
        {
            var viewModel = new PostViewModel();
            viewModel.Categories = this.postService.GetAll<CategoryDropDown>();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPost(PostViewModel input)
        {
            input.Categories = this.postService.GetAll<CategoryDropDown>();
            var userid = this.User.GetUserId();
            input.UserId = this.User.GetUserId();
            var postId = await this.postService.AddPostAsync(input);

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            return this.RedirectToAction("PostById", new { id = postId });
        }
    }
}
