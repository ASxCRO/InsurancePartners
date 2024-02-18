using Partners.Web.Data.Entities;
using Partners.Web.Models;
using System.Collections.Generic;

namespace Partners.Web.Data.Repositories
{
    public interface IPartnerRepository : IRepository<Partner>
    {
        IEnumerable<PartnerWithPolicySummary> GetPartnersWithPolicySummary();
    }
}