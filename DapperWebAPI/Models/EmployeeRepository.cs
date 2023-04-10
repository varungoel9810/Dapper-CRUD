using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DapperWebAPI.Models
{
    public class EmployeeRepository
    {
        
            private string conStr;
            public EmployeeRepository()
            {
                conStr = @"Persist Security Info=False;User Id = SVC_TRANING;password=Gemini@123;Initial Catalog=training_db;Data Source=10.50.18.16;Connection Timeout = 100000";
            }

            public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(conStr);
            }
        }
        //INSERT
        public void Add(Employee employee)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string sql = @"INSERT INTO EMPLOYEEINFO (EmpName,Designation,Department) VALUES (@EmpName,@Designation,@Department)";
                dbConnection.Open();
                dbConnection.Execute(sql, employee);
            }
        }
        //GET ALL
        public IEnumerable<Employee> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"SELECT * FROM EMPLOYEEINFO";
                dbConnection.Open();
                return dbConnection.Query<Employee>(sql);
            }

        }

        //GET BY ID
        public Employee GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"SELECT * FROM EMPLOYEEINFO WHERE EmpId=@id";
                dbConnection.Open();
                return dbConnection.Query<Employee>(sql,new {ID=id}).FirstOrDefault();
            }

        }
        // UPDATE
        public void Update(Employee employee)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"UPDATE EMPLOYEEINFO SET EmpName=@EmpName,Designation=@Designation,Department=@Department WHERE EmpId=@EmpId";
                dbConnection.Open();
                dbConnection.Query(sql,employee);
            }

        }

        // DELETE
        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sql = @"DELETE FROM EMPLOYEEINFO WHERE EmpId=@id";
                dbConnection.Open();
                dbConnection.Query(sql, new {Id=id});
            }

        }
    }
    
}
