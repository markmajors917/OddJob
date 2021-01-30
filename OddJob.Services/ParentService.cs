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
    public class ParentService
    {
        private readonly Guid _userId;

        public ParentService(Guid userId)
        {
            _userId = userId;
        }
        // C
        public bool CreateParent(ParentCreate model)
        {
            var entity =
                new Parent()
                {
                    UserId = _userId,
                    JobId = model.JobId,
                    ParentId = model.ParentId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Parents.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        // R - Index
        public IEnumerable<ParentListItem> GetParents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Parents
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new ParentListItem
                                {
                                    FirstName = e.FirstName,
                                    LastName = e.LastName
                                }
                        );

                return query.ToArray();
            }

        }
        // R - Details
        public ParentDetail GetParentId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Parents
                        .Single(e => e.JobId == id && e.OwnerId == _userId);
                return
                    new ParentDetail
                    {
                        ParentId = entity.ParentId,
                        JobId = entity.JobId,
                        LastName = entity.LastName,
                        FirstName = entity.FirstName,

                    };
            }
        }
        // U
        public bool UpdateParent(ParentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Parents
                        .Single(e => e.JobId == model.JobId && e.OwnerId == _userId);

                entity.ParentApproval = model.ParentApproval;



                return ctx.SaveChanges() == 1;
            }
        }
        // D
        public bool DeleteParent(int jobId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Parents
                        .Single(e => e.JobId == jobId && e.OwnerId == _userId);

                ctx.Parents.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}

    

