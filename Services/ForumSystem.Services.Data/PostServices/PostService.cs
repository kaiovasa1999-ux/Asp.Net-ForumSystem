namespace ForumSystem.Services.Data.PostServices
{
    using System.Threading.Tasks;

    using ForumSystem.Data.Common.Repositories;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.ViewModels.Post;

    public class PostService : IPostService
    {
        private readonly IDeletableEntityRepository<Post> postRepo;

        public PostService(IDeletableEntityRepository<Post> postRepo)
        {
            this.postRepo = postRepo;
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
    }
}
