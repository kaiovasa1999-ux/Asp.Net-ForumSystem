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

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            var query = this.categoryRepo.All().OrderBy(x => x.Title).AsQueryable();
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }
    }
}
