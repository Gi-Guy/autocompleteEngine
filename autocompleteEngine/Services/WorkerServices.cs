using autocompleteEngine.Entity;

namespace autocompleteEngine.Services
{
    public class WorkerServices
    {
        /**
         * This methos will return a list of top 50 workers in the db.
         * @param DataContext
         * @return List
         */
        public async Task<List<Worker>> getTopWorkers(DataContext dataContext)
        {
            string Query = $"select TOP (50) * from dbo.Workers";
            List<Worker> workers = await dataContext.Workers.FromSqlRaw(Query).ToListAsync();
            
            return workers;
        }
        /**
         * This method will accept string 'str' and data connection and return a list of workers 
         * who match to str by name or work title.
         * @param string
         * @param DataContext
         * @return List
         */
        public async Task<List<Worker>> getWorkersByStrAsync(string str, DataContext dataContext)
        {
            string Query = $"select * from dbo.Workers where name LIKE '%{str}%' OR workTitle LIKE '%{str}%'";

            List<Worker> workers = await dataContext.Workers.FromSqlRaw(Query).ToListAsync();

            return workers;
        }
        /**
         * This method will accept int 'id' and a data connection and return a list of one worker 
         * who match to id input by id value.
         * @param int
         * @param DataContext
         * @return List
         */
        public async Task<List<Worker>> getWorkersByIdAsync(int id, DataContext dataContext)
        {
            string Query = $"select * from dbo.Workers where id = '{id}'";

            List<Worker> workers = await dataContext.Workers.FromSqlRaw(Query).ToListAsync();

            return workers;
        }

        /**
         * This method will add new Worker object into the db.
         * @param Worker obj
         * @param DataContext
         */
        public async Task addWorker(Worker worker, DataContext dataContext)
        {
            try
            {
                dataContext.Workers.Add(worker);
                await dataContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
