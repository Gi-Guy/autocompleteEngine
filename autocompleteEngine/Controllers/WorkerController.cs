using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using autocompleteEngine.Entity;
using autocompleteEngine.Services;


namespace autocompleteEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly DataContext dataContext;
        private WorkerServices workerServices;

        public WorkerController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        /**
         * This method will return a list of top 100 workers in the DB
         * @return List
         */
        [HttpGet]
        public async Task<ActionResult<List<Worker>>> Get()
        {
            workerServices = new WorkerServices();
            List<Worker> workers = await workerServices.getTopWorkers(dataContext).ConfigureAwait(false);

            // Check if list is empty or null
            if (workers == null || workers.Count == 0)
                return BadRequest("Worker not found.");
            return Ok(workers);
        }
        /**
         * This method will accept an string and will return a list of workers who
         * match the string by name or work title.
         * @param string 
         * @return List
         */
        [HttpGet("{str}")]
        public async Task<ActionResult<List<Worker>>> Get(string str)
        {
            workerServices = new WorkerServices();
            // keeping all matches workers with str
            List<Worker> workers = await workerServices.getWorkersAsync(str, dataContext).ConfigureAwait(false);

            // Check if list is empty or null
            if (workers == null || workers.Count == 0)
                return BadRequest("Worker not found.");
            return Ok(workers);
        }

        /*  This section is not part of the CRUD api actions, but is for testing the engine */
        [HttpPost]
        public async Task<ActionResult<List<Worker>>> addWorkers()
        {
            await this.addWorkersToDB();
            return Ok();
        }
        private async Task addWorkersToDB()
        {
            workerServices = new WorkerServices();
            await workerServices.addWorker(new Worker("Guy", "software engineer", "a"), dataContext);
            await workerServices.addWorker(new Worker("Avi", "software engineer", "a"), dataContext);
            await workerServices.addWorker(new Worker("Adi", "software engineer", "b"), dataContext);
            await workerServices.addWorker(new Worker("Inbar", "Data engineer", "b"), dataContext);
            await workerServices.addWorker(new Worker("Yosi", "Data engineer", "b"), dataContext);
            await workerServices.addWorker(new Worker("Bobi", "Something engineer", "c"), dataContext);
            await workerServices.addWorker(new Worker("user1", "Something engineer", "c"), dataContext);
            await workerServices.addWorker(new Worker("user2", "Something engineer", "c"), dataContext);
        }
    }
}
