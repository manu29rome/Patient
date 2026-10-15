using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Patent.Application.Interfaces;
using Patent.Domain.Entities;
using System.Collections;

namespace Patent.Infrastructure.Repositories
{
    public class PatentRepository(IConfiguration configuration): IPatentRepository
    {
        private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection") 
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        private SqlCommand CreateCommand(SqlConnection connection, string sp) => 
            new SqlCommand(sp, connection) { CommandType = System.Data.CommandType.StoredProcedure };

        private PatientEntity Map(SqlDataReader reader) => new PatientEntity
        {
            idPatient = reader.GetInt32(reader.GetOrdinal("idPatient")),
            TypeDocument = reader.GetString(reader.GetOrdinal("TypeDocument")),
            numberDocument = reader.GetInt64(reader.GetOrdinal("numberDocument")),
            namePatient = reader.GetString(reader.GetOrdinal("namePatient")),
            dateBirth = reader.GetDateTime(reader.GetOrdinal("dateBirth")),
            email = reader.GetString(reader.GetOrdinal("email")),
            Gender = reader.GetString(reader.GetOrdinal("Gender")),
            address = reader.GetString(reader.GetOrdinal("address")),
            numberPhone = reader.GetInt64(reader.GetOrdinal("numberPhone")),
            active = reader.GetBoolean(reader.GetOrdinal("active")),
        };

        public async Task<IEnumerable<PatientEntity>> GetListAsync()
        {
            try
            {
                List<PatientEntity> patients = new List<PatientEntity>();
                await using SqlConnection connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();
                using SqlCommand command = CreateCommand(connection, "sp_ListPatient");
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        patients.Add(Map(reader));
                    }
                }
               
                return patients;

            }
            catch(Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }

        
    }
}
