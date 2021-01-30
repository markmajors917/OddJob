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
    public class ContractorService
    {
        private readonly Guid _userId;

        public ContractorService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateContractor(ContractorCreate model)
        {
            var entity =
                new Contractor()
                {
                    UserId = _userId,
                    LastName = model.LastName,
                    FirstName = model.FirstName
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Contractors.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        public IEnumerable<ContractorList> GetContractors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Contractors
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new ContractorList
                                {
                                    LastName = e.LastName,
                                    FirstName = e.FirstName,
                                    Age = e.Age
                                }
                        )
                .ToList();

                return query.ToArray();
            }
        }
     
        public ContractorDetail GetContractorById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Contractors
                        .Single(e => e.JobId == id && e.OwnerId == _userId);
                return
                    new ContractorDetail
                    {
                        Age = entity.Age,
                        
                    };
            }

        }
        public bool UpdateContractor(ContractorEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Contractors
                        .Single(e => e.JobId == model.JobId && e.OwnerId == _userId);

                entity.Age = model.Age;
               
                return ctx.SaveChanges() == 1;
            }
        }

        // D
        public bool DeleteContractor(int contractorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Contractors
                        .Single(e => e.JobId == contractorId && e.OwnerId == _userId);

                ctx.Contractors.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}