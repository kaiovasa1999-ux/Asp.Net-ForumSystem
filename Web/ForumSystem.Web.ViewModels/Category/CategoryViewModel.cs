namespace ForumSystem.Web.ViewModels.Category
{
    using System.Collections.Generic;

    public class CategoryViewModel
    {
        public ICollection<PostViewModel> Posts { get; set; }
    }
}
