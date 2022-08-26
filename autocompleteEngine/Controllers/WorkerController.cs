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
    }
}
