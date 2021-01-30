using OddJob.Data;
using OddJob.Datal;
using OddJob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddJob.Services
{
    public class JobService
    {
        private readonly Guid _userId;

        public JobService(Guid userId)
        {
            _userId = userId;
        }
        // C
        public bool CreateJob(CreateJob model)
        {
            var entity =
                new Job()
                {
                    //Match the model. All required items
                    UserId = _userId,
                    JobName = model.JobName,
                    JobDescription = model.JobDescription,
                    CreatedAt = DateTime.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Jobs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
            // R - Index use list item model, include all properties to interact with. 
        }
        public IEnumerable<JobListItem> GetJobs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Jobs
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new JobListItem
                                {
                                    JobId = e.JobId,
                                    JobName = e.JobName,
                                    JobDescription = e.JobDescription
                                }
                        );

                return query.ToArray();
            }
        }
        // R - Details
        public JobDetail GetJobById(int id)
            {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Jobs
                        .Single(e => e.JobId == id && e.OwnerId == _userId);
                return
                    new JobDetail
                    {
                        JobId = entity.JobId,
                        City = entity.City,
                        Price = entity.Price,
                        EstimatedHours = entity.EstimatedHours,
                        CreatedAt = entity.CreatedAt
                    };
            }
        }

        // U
        public bool UpdateJob(JobEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Jobs
                        .Single(e => e.JobId == model.JobId && e.OwnerId == _userId);

                entity.JobName = model.JobName;
                entity.JobDescription = model.JobDescription;
                entity.Price = model.Price;
                entity.EstimatedHours = model.EstimatedHours;
               

                return ctx.SaveChanges() == 1;
            }
        }
        // D
        public bool DeleteJob(int jobId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Jobs
                        .Single(e => e.JobId == jobId && e.OwnerId == _userId);

                ctx.Jobs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }



        


    }
    
}
