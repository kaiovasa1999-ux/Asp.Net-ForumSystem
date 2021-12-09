namespace ForumSystem.Services.Data.PostServices
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using ForumSystem.Web.ViewModels.Post;

    public interface IPostService
    {
        Task<int> AddPostAsync(PostViewModel input);

        IEnumerable<CategoryDropDown> GetCategoryTitles();
    }
}
