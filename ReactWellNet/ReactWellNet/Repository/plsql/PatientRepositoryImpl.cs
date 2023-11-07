using Microsoft.Extensions.Options;
using ReactWellNet.Repository;
using ReactWellNet.domain;
using Npgsql;
using ReactWellNet.Setting;
using System.Data;
using System.Text.Json;


namespace ReactWellNet.Repository.plsql;

public class PatientRepositoryImpl : IPatientRepository {
    private  readonly ConnectionSetting _connStr;
    public PatientRepositoryImpl(IOptions<ConnectionSetting> connStr) {
        _connStr = connStr.Value;
    }

    public async Task<Patient?> GetPatient(int patientId) {
        Patient? patient = null;
        using (var connect = new NpgsqlConnection(_connStr.SQLString)) {
            connect.Open();

            await using var cmd = new NpgsqlCommand("select public.getpatient(@p);", connect) {
                Parameters = {
                    new( "p", patientId )
                }
            };

            using var reader = await cmd.ExecuteReaderAsync();
            await reader.ReadAsync();
            string json = (string)reader["getpatient"];
            if (json != null) {
                patient = JsonSerializer.Deserialize<Patient>(json);
            }
        }
        return patient;
    }
    //todo
    //public async Task<int> updatePatient(int patientId, Patient patient) {
    //    using (var connect = new NpgsqlConnection(_connStr.SQLString)) {
    //        connect.Open();
    //        NpgsqlCommand cmd = connect.CreateCommand();
    //        cmd.CommandText = "select public.getpatient(?);";
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        using (var reader = await cmd.ExecuteReaderAsync()) {
    //            await reader.ReadAsync();
    //            string json = (string)reader["getpatient"];

    //            if (json != null) {
    //                patient = JsonSerializer.Deserialize<Patient>(json);
    //                return patient;
    //            }

    //        }
    //    }

    //    return null;
    //}
}
