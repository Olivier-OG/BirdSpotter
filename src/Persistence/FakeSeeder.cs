using Domain.Birds;

namespace Persistence;

public class FakeSeeder
{
    private readonly ApplicationDbContext dbContext;

    public FakeSeeder(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Seed()
    {
        // Not a good idea in production.
        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();

        SeedBirds();
    }

    private void SeedBirds()
    {
        if (dbContext.Birds.Any())
        {
            return;
        }

        Bird b1 = new("Skylark", "https://randomoutputs.com/assets/images/tools/birds/skylark.webp");
        Bird b2 = new("Grey Partridge", "https://randomoutputs.com/assets/images/tools/birds/grey-partridge-adult-male.webp");
        Bird b3 = new("Water Rail", "https://randomoutputs.com/assets/images/tools/birds/water-rail.webp");
        Bird b4 = new("Great White Egret", "https://randomoutputs.com/assets/images/tools/birds/great-white-egret.webp");
        Bird b5 = new("Chaffinch Male", "https://randomoutputs.com/assets/images/tools/birds/chaffinch-male.webp");
        Bird b6 = new("Chiffchaff", "https://randomoutputs.com/assets/images/tools/birds/chiffchaff.webp");
        Bird b7 = new("Tree Sparrow", "https://randomoutputs.com/assets/images/tools/birds/tree-sparrow.webp");
        Bird b8 = new("Barn Owl", "https://randomoutputs.com/assets/images/tools/birds/barn-owl.webp");
        Bird b9 = new("Goldfinch Adult", "https://randomoutputs.com/assets/images/tools/birds/woodlark.webp");
        Bird b10 = new("Wren", "https://randomoutputs.com/assets/images/tools/birds/wren.webp");

        dbContext.AddRange(b1, b2, b3, b4, b5, b6, b7, b8, b9, b10);
        dbContext.SaveChanges();
    }
}

