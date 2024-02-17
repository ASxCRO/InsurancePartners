namespace Partners.Web.Data.Entities
{
    public class Policy : BaseEntity<int>
    {
        public int PartnerId { get; set; }
        public string PolicyNumber { get; set; }
        public decimal PolicyAmount { get; set; }
    }
}