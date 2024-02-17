using Dapper;
using Partners.Web.Data.Entities;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Partners.Web.Data.Repositories
{
    public class PolicyRepository : IRepository<Policy>
    {
        private readonly string _connectionString;

        public PolicyRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Add(Policy policy)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO Policies (PartnerId, PolicyNumber, PolicyAmount) VALUES (@PartnerId, @PolicyNumber, @PolicyAmount)";
                db.Execute(sql, policy);
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = "DELETE FROM Policies WHERE Id = @Id";
                db.Execute(sql, new { Id = id });
            }
        }

        public void Update(Policy policy)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE Policies SET PartnerId = @PartnerId, PolicyNumber = @PolicyNumber, PolicyAmount = @PolicyAmount WHERE Id = @Id";
                db.Execute(sql, policy);
            }
        }

        public Policy FindByID(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Policies WHERE Id = @Id";
                return db.QueryFirstOrDefault<Policy>(sql, new { Id = id });
            }
        }

        public IEnumerable<Policy> FindAll()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Policies";
                return db.Query<Policy>(sql);
            }
        }
    }
}