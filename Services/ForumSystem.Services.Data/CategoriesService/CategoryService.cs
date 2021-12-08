namespace ForumSystem.Services.Data.CategoriesService
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ForumSystem.Data.Common.Repositories;
    using ForumSystem.Data.Models;
    using ForumSystem.Services.Mapping;
    using ForumSystem.Web.ViewModels.Categories;
    using ForumSystem.Web.ViewModels.Home;

    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepo;

        public CategoryService(IDeletableEntityRepository<Category> categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        public IEnumerable<IndexCategriesViewModel> GetAll()
        {
            return this.categoryRepo.All().Where(c => c.Id != 0).Select(x => new IndexCategriesViewModel { Id = x.Id, Title = x.Title, ImageUrl = x.ImageUrl, PostsCount = x.Posts.Count() }).ToList();
        }

        public T GetByTitle<T>(string title)
        {
            return this.categoryRepo.All().Where(c => c.Title == title).To<T>().FirstOrDefault();
        }
    }
}
