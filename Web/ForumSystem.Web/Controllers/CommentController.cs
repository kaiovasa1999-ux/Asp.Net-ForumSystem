namespace ForumSystem.Web.Controllers
{
    using System.Linq;

    using ForumSystem.Data;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.IdenityHellpMethod;
    using ForumSystem.Web.ViewModels.Comment;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CommentController : Controller
    {
        private readonly ApplicationDbContext data;

        public CommentController(ApplicationDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public IActionResult AddCommentForPostById()
        {
            var view = new CommentViewModel();
            return this.View(view);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddCommentForPostById(string title, CommentViewModel input)
        {
            var viewModel = new CommentViewModel();
            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            var post = this.data.Posts.Where(p => p.Title == title).FirstOrDefault();
            var userid = this.User.GetUserId();
            input.UserUsername = this.User.Identity.Name;
            var comment = new Comment
            {
                Content = input.Content,
                UserId = userid,
            };
            post.Comments.Add(comment);

            return this.RedirectToAction("PostById", "Post");
        }
    }
}
