using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
        }

        public DbSet<Armor> Armors { get; set; }
        public DbSet<Biom> Bioms { get; set; }
        public DbSet<NPC> NPCs { get; set; }
        public DbSet<Enchantment> Enchantments { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Perks> Perks { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<Scream> Screams { get; set; }
        public DbSet<Spell> Spells { get; set; }
        public DbSet<Talent> Talents { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
    }
}
