using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Net14Web.DbStuff.Models.LifeScore;

namespace Net14Web.DbStuff.Configurations.LifeScore
{
    public class SportGameConfiguration : IEntityTypeConfiguration<SportGame>
    {
        public void Configure(EntityTypeBuilder<SportGame> builder)
        {
            builder.ToTable("SportGames", "dbo");
            builder.HasKey(x => x.Id);
        }
    }
}
