using JobAPI.Models;

namespace JobAPI.Repository
{
    public interface IJobRepository
    {
        int AddJob(Job job);
        bool BlockJob(Job jobEditObject);
        bool Deletejob(Job jobDeleteDetails);
        bool EditJob(Job jobEditObject, Job newJob);
        List<Job> GetAllJobs();
        List<Job> GetJobByCategory(string category);
        List<Job> GetJobByCompany(string company);
        Job GetJobById(int jobId);
        List<Job> GetJobBySalaryRange(decimal minSalary, decimal maxsalary);
        List<Job> GetJobByTitle(string title);
        Job IsJobExist(string? jobTitle, string? companyName);
        bool UnblockJob(Job jobEditObject);
    }
}
