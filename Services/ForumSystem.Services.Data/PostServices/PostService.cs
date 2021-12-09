namespace ForumSystem.Services.Data.PostServices
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ForumSystem.Data.Common.Repositories;
    using ForumSystem.Data.Models;
    using ForumSystem.Services.Mapping;
    using ForumSystem.Web.ViewModels.Post;

    public class PostService : IPostService
    {
        private readonly IDeletableEntityRepository<Post> postRepo;
        private readonly IDeletableEntityRepository<Category> categoryRepo;

        public PostService(IDeletableEntityRepository<Post> postRepo, IDeletableEntityRepository<Category> categoryRepo)
        {
            this.postRepo = postRepo;
            this.categoryRepo = categoryRepo;
        }

        public async Task<int> AddPostAsync(PostViewModel input)
        {
            var post = new Post
            {
                Title = input.Title,
                CategoryId = input.CategoryId,
                UserId = input.UserId,
                Contnet = input.Contnet,
            };

            await this.postRepo.AddAsync(post);
            await this.postRepo.SaveChangesAsync();
            return input.Id;
        }

        public IEnumerable<CategoryDropDown> GetCategoryTitles()
        {
            var categories = this.categoryRepo.All().Select(c => new CategoryDropDown
            {
                Id = c.Id,
                Title = c.Title,
            })
                .ToList();
            return categories;
        }

        public IEnumerable<T> GetCategoryTitles<T>()
        {
            var query = this.categoryRepo.All().OrderBy(x => x.Title).AsQueryable();
            return query.To<T>().ToList();
        }
    }
}
