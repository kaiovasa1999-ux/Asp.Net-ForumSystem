namespace ForumSystem.Services.Data.CategoriesService
{
    using System.Collections.Generic;
    using System.Linq;

    using ForumSystem.Data.Common.Repositories;
    using ForumSystem.Data.Models;
    using ForumSystem.Services.Mapping;
    using ForumSystem.Web.ViewModels.Home;

    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepo;

        public CategoryService(IDeletableEntityRepository<Category> categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        public IndexCategriesViewModel FindByTitle(string title)
        {
            var category = this.categoryRepo.All().Where(c => c.Title == title)
                .Select(c => new IndexCategriesViewModel { Title = c.Title, Id = c.Id, ImageUrl = c.ImageUrl }).FirstOrDefault();
            return category;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            var categories = this.categoryRepo.All().OrderBy(r => r.Title).AsQueryable();
            if (count.HasValue)
            {
                categories.Take(count.Value);
            }

            return categories.To<T>().ToList();
        }
    }
}
