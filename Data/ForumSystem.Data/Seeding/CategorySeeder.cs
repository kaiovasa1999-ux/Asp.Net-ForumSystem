namespace ForumSystem.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ForumSystem.Data.Models;

    public class CategorySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category { Title = "Sports", ImageUrl = "https://www.armaghbanbridgecraigavon.gov.uk/wp-content/uploads/2019/04/sportsballs1.png", Description = "Sports" });
            await dbContext.Categories.AddAsync(new Category { Title = "Programing", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTMyOsTlM7QZNEDFjsPLWTDroHyM84qrqcBpA&usqp=CAU", Description = "Programing" });
            await dbContext.Categories.AddAsync(new Category { Title = "Politics", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRCC-9gNUK-8E1x8A64qHr-Nx_8wtdmWBeYoA&usqp=CAU", Description = "Politics" });
            await dbContext.Categories.AddAsync(new Category { Title = "Gaming", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT_j1BvI18UgyQyJcPYhvjx_Mfn1BNAlp6Ngg&usqp=CAU", Description = "Gaming" });
            await dbContext.Categories.AddAsync(new Category { Title = "Dogs", ImageUrl = "https://www.dogstrust.org.uk/sponsor/_dogs/bubba-assets/v800_bubba1.jpg", Description = "Dogs" });
            await dbContext.Categories.AddAsync(new Category { Title = "Cats", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0b/Cat_poster_1.jpg/520px-Cat_poster_1.jpg", Description = "Cats" });
            await dbContext.Categories.AddAsync(new Category { Title = "Houses", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6a/248_Ashley_Ave_-_2017.jpg/264px-248_Ashley_Ave_-_2017.jpg", Description = "Houses" });
            await dbContext.Categories.AddAsync(new Category { Title = "Finance", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d7/Philippine-stock-market-board.jpg/500px-Philippine-stock-market-board.jpg", Description = "Finance" });
            await dbContext.SaveChangesAsync();
        }
    }
}
