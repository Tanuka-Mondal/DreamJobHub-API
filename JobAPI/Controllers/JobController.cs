using JobAPI.AOP;
using JobAPI.Logging;
using JobAPI.Models;
using JobAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobAPI.Controllers
{
    [ServiceFilter(typeof(JobLogger))]
    [JobExceptionHandler]
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        readonly IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        [Route("getAllJobs")]
        public ActionResult GetAllUsers()
        {
            List<Job> jobs = _jobService.GetAllJobs();
            return Ok(jobs);
        }

        [HttpPost]
        [Route("addJob")]
        public ActionResult AddJob(Job job)
        {
            int jobAddResult = _jobService.AddJob(job);
            return Created("api/addjob", jobAddResult);
        }

        [HttpDelete]
        [Route("deleteJob")]
        public ActionResult DeleteJob(int jobId)
        {
            bool jobDeleteResult = _jobService.DeleteJob(jobId);
            return Ok(jobDeleteResult);
        }

        [HttpPut]
        [Route("editJob")]
        public ActionResult EditJob(int id, Job newJob)
        {
            bool jobEditResult = _jobService.EditJob(id, newJob);
            return Ok(jobEditResult);
        }

        [HttpPatch]
        [Route("blockJob")]
        public ActionResult BlockJob(int id)
        {
            bool jobBlockResult = _jobService.BlockJob(id);
            return Ok(jobBlockResult);
        }

        [HttpPatch]
        [Route("unblockJob")]
        public ActionResult UnblockJob(int id)
        {
            bool jobUnblockResult = _jobService.UnblockJob(id);
            return Ok(jobUnblockResult);
        }

        [HttpGet]
        [Route("getJobById/{id:int}")]

        public ActionResult GetJobById(int id)
        {
            Job job = _jobService.GetJobById(id);
            return Ok(job);
        }

        [HttpGet]
        [Route("getJobByTitle")]
        public ActionResult GetJobByTitle(string title)
        {
            List<Job> jobs = _jobService.GetJobByTitle(title);
            return Ok(jobs);
        }

        [HttpGet]
        [Route("getJobByCompany")]
        public ActionResult GetJobByCompany(string company)
        {
            List<Job> jobs = _jobService.GetJobByCompany(company);
            return Ok(jobs);
        }

        [HttpGet]
        [Route("getJobByCategory")]
        public ActionResult GetJobByCategory(string category)
        {
            List<Job> jobs = _jobService.GetJobByCategory(category);
            return Ok(jobs);
        }

        [HttpGet]
        [Route("getJobBySalaryRange")]
        public ActionResult GetJobBySalaryRange(decimal minSalary, decimal maxsalary)
        {
            List<Job> jobs = _jobService.GetJobBySalaryRange(minSalary,maxsalary);
            return Ok(jobs);
        }
    }
}
