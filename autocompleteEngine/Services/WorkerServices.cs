using autocompleteEngine.Entity;

namespace autocompleteEngine.Services
{
    public class WorkerServices
    {
        /**
         * This method will accept string 'str' and data connection to the db and will return a list of workers 
         * who match to str by name or work title.
         * @param string
         * @param DataContext
         * @return List
         */
        public async Task<List<Worker>> getWorkersAsync(string str, DataContext dataContext)
        {
            string Query = $"select * from dbo.Workers where name LIKE '%{str}%' OR workTitle LIKE '%{str}%'";

            List<Worker> workers = await dataContext.Workers.FromSqlRaw(Query).ToListAsync();

            return workers;
        }
    }
}
