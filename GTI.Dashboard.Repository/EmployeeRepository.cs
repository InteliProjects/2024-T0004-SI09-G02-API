using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Dashboard.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _dbConfig;

        public EmployeeRepository(string dbConfig)
        {
            _dbConfig = dbConfig;
        }

        public async Task<EmployeeModel> GetEmployeeById(int id)
        {
            using (var conn = new NpgsqlConnection(_dbConfig))
            {
                await conn.OpenAsync();
                return (EmployeeModel)await conn.QueryAsync<EmployeeModel>(@"
                    SELECT
                        cargo as Cargo,
                        sg_emp as SgEmp,
                        texto_rh as TextoRh,
                        data_nascimento as DataNascimento,
                        n_pessoal as NPessoal,
                        centro_custo as CentroCusto,
                        centro_cst as CentroCst
                    FROM 
                        empregados
                    WHERE
                        id = @Id
                    LIMIT 100
                ", new {Id = id});
            };
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployees()
        {
            using (var conn = new NpgsqlConnection(_dbConfig))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<EmployeeModel>(@"
                    SELECT
                        cargo as Cargo,
                        sg_emp as SgEmp,
                        texto_rh as TextoRh,
                        data_nascimento as DataNascimento,
                        n_pessoal as NPessoal,
                        centro_custo as CentroCusto,
                        centro_cst as CentroCst
                    FROM 
                        empregados
                    LIMIT 100
                ");
            };
        }

        public Task<int> InsertEmployee(EmployeeModel employeeModel)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateEmployee(EmployeeModel employeeModel)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
