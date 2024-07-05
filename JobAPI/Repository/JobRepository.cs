using JobAPI.Context;
using JobAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JobAPI.Repository
{
    public class JobRepository : IJobRepository
    {
        readonly JobDbContext _jobDbContext;
        public JobRepository(JobDbContext jobDbContext)
        {
            _jobDbContext = jobDbContext;
        }
        public int AddJob(Job job)
        {
            _jobDbContext.Jobs.Add(job);
            int changes = _jobDbContext.SaveChanges();
            return changes;
        }

        public bool BlockJob(Job jobEditObject)
        {
            jobEditObject.IsBlocked = true;
            _jobDbContext.Entry(jobEditObject).State = EntityState.Modified;
            int changes = _jobDbContext.SaveChanges();
            return changes > 0;
        }

        public bool Deletejob(Job jobDeleteDetails)
        {
            _jobDbContext.Jobs.Remove(jobDeleteDetails);
            int changes = _jobDbContext.SaveChanges();
            return changes > 0;
        }

        public bool EditJob(Job jobEditObject, Job newJob)
        {
            jobEditObject.JobTitle = newJob.JobTitle;
            jobEditObject.JobDescription = newJob.JobDescription;
            jobEditObject.JobLocation = newJob.JobLocation;
            jobEditObject.Category = newJob.Category;
            jobEditObject.CompanyName = newJob.CompanyName;
            jobEditObject.Salary = newJob.Salary;
            jobEditObject.IsBlocked = newJob.IsBlocked;

            _jobDbContext.Entry(jobEditObject).State = EntityState.Modified;
            int changes = _jobDbContext.SaveChanges();
            return changes > 0;
        }

        public List<Job> GetAllJobs()
        {
            return _jobDbContext.Jobs.ToList();
        }

        public List<Job> GetJobByCategory(string category)
        {
            return _jobDbContext.Jobs.Where(j => j.Category == category).ToList();
        }

        public List<Job> GetJobByCompany(string company)
        {
            return _jobDbContext.Jobs.Where(j => j.CompanyName == company).ToList();
        }

        public Job? GetJobById(int jobId)
        {
            return _jobDbContext.Jobs.Where(j => j.Id == jobId).FirstOrDefault();
        }

        public List<Job> GetJobBySalaryRange(decimal minSalary, decimal maxSalary)
        {
            return _jobDbContext.Jobs.Where(j => j.Salary >= minSalary && j.Salary <= maxSalary)
        .ToList();
        }

        public List<Job> GetJobByTitle(string title)
        {
            return _jobDbContext.Jobs.Where(j => j.JobTitle == title).ToList();
        }

        public Job? IsJobExist(string? jobTitle, string? companyName)
        {
            return _jobDbContext.Jobs.Where(j => j.JobTitle == jobTitle && j.CompanyName == companyName).FirstOrDefault();
        }

        public bool UnblockJob(Job jobEditObject)
        {
            jobEditObject.IsBlocked = false;
            _jobDbContext.Entry(jobEditObject).State = EntityState.Modified;
            int changes = _jobDbContext.SaveChanges();
            return changes > 0;
        }
    }
}
