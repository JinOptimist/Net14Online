using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Net14Web.DbStuff.Models.LifeScore;

namespace Net14Web.DbStuff.Configurations.LifeScore
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Players", "dbo");
            builder.HasKey(x => x.Id);
        }
    }
}
