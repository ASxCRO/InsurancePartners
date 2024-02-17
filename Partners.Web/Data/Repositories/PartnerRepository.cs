using Dapper;
using Partners.Web.Data.Entities;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Partners.Web.Data.Repositories
{
    public class PartnerRepository : IRepository<Partner>
    {
        private readonly string _connectionString;

        public PartnerRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Add(Partner partner)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                partner.CreateByUser = "sqluser";
                string sql = @"INSERT INTO Partners (FirstName, LastName, Address, PartnerNumber, CroatianPIN, PartnerTypeId, CreateByUser, IsForeign, ExternalCode, Gender)
                           VALUES (@FirstName, @LastName, @Address, @PartnerNumber, @CroatianPIN, @PartnerTypeId, @CreateByUser, @IsForeign, @ExternalCode, @Gender)";
                db.Execute(sql, partner);
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = "DELETE FROM Partners WHERE Id = @Id";
                db.Execute(sql, new { Id = id });
            }
        }

        public void Update(Partner partner)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE Partners SET FirstName = @FirstName, LastName = @LastName, Address = @Address, PartnerNumber = @PartnerNumber,
                           CroatianPIN = @CroatianPIN, PartnerTypeId = @PartnerTypeId,
                           IsForeign = @IsForeign, ExternalCode = @ExternalCode, Gender = @Gender WHERE Id = @Id";
                db.Execute(sql, partner);
            }
        }

        public Partner FindByID(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Partners WHERE Id = @Id";
                return db.QueryFirstOrDefault<Partner>(sql, new { Id = id });
            }
        }

        public IEnumerable<Partner> FindAll()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Partners";
                return db.Query<Partner>(sql);
            }
        }
    }
}