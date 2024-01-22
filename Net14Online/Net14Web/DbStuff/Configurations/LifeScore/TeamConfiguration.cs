using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Net14Web.DbStuff.Models.LifeScore;

namespace Net14Web.DbStuff.Configurations.LifeScore
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Teams", "dbo");
            builder.HasKey(x => x.Id);
        }
    }
}
