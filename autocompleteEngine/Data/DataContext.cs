using autocompleteEngine.Entity;


namespace autocompleteEngine.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Worker> Workers { get; set; }
    }
}
