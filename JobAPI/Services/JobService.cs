using JobAPI.Exceptions;
using JobAPI.Models;
using JobAPI.Repository;

namespace JobAPI.Services
{
    public class JobService : IJobService
    {
        readonly IJobRepository _jobRepository;
        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }
        public int AddJob(Job job)
        {
            Job jobDetails = _jobRepository.IsJobExist(job.JobTitle,job.CompanyName);
            if (jobDetails == null)
            {
                int addResult = _jobRepository.AddJob(job);
                return addResult;
            }
            else
            {
                throw new DuplicateJobException($"Duplicate job:{job.JobTitle}");
            }
        }

        public bool BlockJob(int id)
        {
            Job jobEditObject = _jobRepository.GetJobById(id);
            if (jobEditObject != null)
            {
                bool blockResult = _jobRepository.BlockJob(jobEditObject);
                return blockResult;
            }
            else
            {
                throw new JobNotFoundException("Job doesn't exist");
            }
        }

        public bool DeleteJob(int jobId)
        {
            Job jobDeleteDetails = _jobRepository.GetJobById(jobId);
            if (jobDeleteDetails != null)
            {
                bool deleteResult = _jobRepository.Deletejob(jobDeleteDetails);
                return deleteResult;
            }
            else
            {
                throw new JobNotFoundException("Job doesn't exist");
            }
        }

        public bool EditJob(int id, Job newJob)
        {
            Job jobEditObject = _jobRepository.GetJobById(id);
            if (jobEditObject != null)
            {
                bool areEqual = jobEditObject.Equals(newJob);
                if (!areEqual)
                {
                    bool editResult = _jobRepository.EditJob(jobEditObject, newJob);
                    return editResult;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                throw new JobNotFoundException("job doesn't exist");
            }
        }

        public List<Job> GetAllJobs()
        {
            return _jobRepository.GetAllJobs();
        }

        public List<Job> GetJobByCategory(string category)
        {
            return _jobRepository.GetJobByCategory(category);
        }

        public List<Job> GetJobByCompany(string company)
        {
            return _jobRepository.GetJobByCompany(company);
        }

        public Job GetJobById(int id)
        {
            Job job = _jobRepository.GetJobById(id);
            if (job != null)
            {
                return job;
            }
            else
            {
                throw new JobNotFoundException("Job Not Found");
            }
        }

        public List<Job> GetJobBySalaryRange(decimal minSalary, decimal maxsalary)
        {
            return _jobRepository.GetJobBySalaryRange(minSalary,maxsalary);
        }

        public List<Job> GetJobByTitle(string title)
        {
            return _jobRepository.GetJobByTitle(title);
        }

        public bool UnblockJob(int id)
        {
            Job jobEditObject = _jobRepository.GetJobById(id);
            if (jobEditObject != null)
            {
                bool unblockResult = _jobRepository.UnblockJob(jobEditObject);
                return unblockResult;
            }
            else
            {
                throw new JobNotFoundException("Job doesn't exist");
            }
        }
    }
}
