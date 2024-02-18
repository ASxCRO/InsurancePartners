using Partners.Web.Data.Entities;

namespace Partners.Web.Models
{
    public class PartnerWithPolicySummary : Partner
    {
        public int NumberOfPolicies { get; set; }
        public decimal TotalPolicyAmount { get; set; }
    }
}