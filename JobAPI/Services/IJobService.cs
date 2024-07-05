using JobAPI.Models;

namespace JobAPI.Services
{
    public interface IJobService
    {
        int AddJob(Job job);
        bool BlockJob(int id);
        bool DeleteJob(int jobId);
        bool EditJob(int id, Job newJob);
        List<Job> GetAllJobs();
        List<Job> GetJobByCategory(string category);
        List<Job> GetJobByCompany(string company);
        Job GetJobById(int id);
        List<Job> GetJobBySalaryRange(decimal minSalary, decimal maxsalary);
        List<Job> GetJobByTitle(string title);
        bool UnblockJob(int id);
    }
}
