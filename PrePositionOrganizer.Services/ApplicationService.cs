using PrePositionOrganizer.Data;
using PrePositionOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrePositionOrganizer.Services
{
    public class ApplicationService
    {
        private readonly Guid _userId;
        public ApplicationService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateApplication(ApplicationCreate model)
        {
            var entity =
                new Application()
                {
                    OwnerId = _userId,
                    CompanyName = model.CompanyName,
                    JobDescription = model.JobDescription,
                    SalaryEstimate = model.SalaryEstimate,
                    JobLocation = model.JobLocation,
                    MyInterest = model.MyInterest,
                    Status = model.Status,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Applications.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ApplicationListItem> GetApplications()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Applications
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ApplicationListItem
                                {
                                    ApplicationId = e.ApplicationId,
                                    CompanyName = e.CompanyName,
                                    JobDescription = e.JobDescription,
                                    CreatedUtc = e.CreatedUtc
                                }
                                );
                return query.ToArray();
            }
        }

        public ApplicationDetail GetApplicationById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Applications
                    .Single(e => e.ApplicationId == id && e.OwnerId == _userId);
                return
                    new ApplicationDetail
                    {
                        ApplicationId = entity.ApplicationId,
                        CompanyName = entity.CompanyName,
                        JobDescription = entity.JobDescription,
                        SalaryEstimate = entity.SalaryEstimate,
                        JobLocation = entity.JobLocation,
                        MyInterest = entity.MyInterest,
                        Status = entity.Status,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
    }
}
