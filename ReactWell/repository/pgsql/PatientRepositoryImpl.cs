using domain;
using Microsoft.Extensions.Options;
using Npgsql;
using setting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace repository.pgsql;
public class PatientRepositoryImpl : IPatientRepository {
    private readonly ConnectionSetting _connStr;
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
    public async Task<int?> updatePatient(int patientId, Patient patient) {
        string json=JsonSerializer.Serialize(patient);
        using (var connect = new NpgsqlConnection(_connStr.SQLString)) {
            connect.Open();

            await using var cmd = new NpgsqlCommand("call public.updatepatient(@pjson::json,@pid)", connect) {
                Parameters = {
                    new("pjson", json),
                    new( "pid", patientId )
                }
            };
            using var reader = await cmd.ExecuteReaderAsync();
            await reader.ReadAsync();
            int? pidOut = (int?)reader["updatepatient"];
            return pidOut;
        }
    }

}
