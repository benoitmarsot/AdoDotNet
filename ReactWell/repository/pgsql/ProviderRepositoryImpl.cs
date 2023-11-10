using domain;
using Microsoft.Extensions.Options;
using Npgsql;
using setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace repository.pgsql;
public class ProviderRepositoryImpl : IProviderRepository {
    private readonly ConnectionSetting _connStr;
    public ProviderRepositoryImpl(IOptions<ConnectionSetting> connStr) {
        _connStr = connStr.Value;
    }
    public async Task<Assessment?> GetAssessment(int providerId, int patientId) {
        Assessment? assessment = null;
        using (var connect = new NpgsqlConnection(_connStr.SQLString)) {
            connect.Open();

            await using var cmd = new NpgsqlCommand("select public.getassessment(@providerId,@patientId);", connect) {
                Parameters = {
                    new( "providerId", providerId ),
                    new( "patientId", patientId )
                }
            };

            using var reader = await cmd.ExecuteReaderAsync();
            await reader.ReadAsync();
            string json = (string)reader["getassessment"];
            if (json != null) {
                assessment = JsonSerializer.Deserialize<Assessment>(json);
            }
        }
        return assessment;
    }

    public async Task<int?> Register(Provider provider) {
        string json = JsonSerializer.Serialize(provider);
        using (var connect = new NpgsqlConnection(_connStr.SQLString)) {
            connect.Open();

            await using var cmd = new NpgsqlCommand("call public.registerprovider(@pjson::json)", connect) {
                Parameters = {
                    new("pjson", json)
                }
            };
            using var reader = await cmd.ExecuteReaderAsync();
            await reader.ReadAsync();
            int? provid = (int?)reader["provid"];
            return provid;
        }
    }

    public async Task<int?> RegisterPatient(int providerId, Patient patient) {
        string json = JsonSerializer.Serialize(patient);
        using (var connect = new NpgsqlConnection(_connStr.SQLString)) {
            connect.Open();

            await using var cmd = new NpgsqlCommand(
                "call public.registerpatient(@providerId,@patient::json)", connect
            ) {
                Parameters = {
                    new( "providerId", providerId ),
                    new( "pjson", json)
                }
            };
            using var reader = await cmd.ExecuteReaderAsync();
            await reader.ReadAsync();
            int? pid = (int?)reader["pid"];
            return pid;
        }
    }

    public async Task<int?> SaveAssessment(int providerId, int patientId, Assessment assessment) {
        string json = JsonSerializer.Serialize(assessment);
        using (var connect = new NpgsqlConnection(_connStr.SQLString)) {
            connect.Open();

            await using var cmd = new NpgsqlCommand(
                "call public.saveassessment(@providerId,@patientId,@assessjson::json)", connect
            ) {
                Parameters = {
                    new( "providerId", providerId ),
                    new( "patientId", patientId ),
                    new( "assessjson", json)
                }
            };
            using var reader = await cmd.ExecuteReaderAsync();
            await reader.ReadAsync();
            int? pid = (int?)reader["pid"];
            return pid;
        }
    }

    public async Task<Provider?> Signin(Credential credential) {
        string json = JsonSerializer.Serialize(credential);
        using (var connect = new NpgsqlConnection(_connStr.SQLString)) {
            connect.Open();

            await using var cmd = new NpgsqlCommand("select public.providersignin(@cred::json);", connect) {
                Parameters = {
                    new("cred", json)
                }
            };
            using var reader = await cmd.ExecuteReaderAsync();
            await reader.ReadAsync();
            Provider? provider = null;
            string? jsonOut = (string?)reader["providersignin"];
            if (jsonOut != null) {
                provider = JsonSerializer.Deserialize<Provider>(jsonOut);
            }
            return provider;
        }
    }

    public async Task<int?> UpdateProvider(Provider provider) {
        string json = JsonSerializer.Serialize(provider);
        using (var connect = new NpgsqlConnection(_connStr.SQLString)) {
            connect.Open();

            await using var cmd = new NpgsqlCommand(
                "call public.updateprovider(@provider::json)", connect
            ) {
                Parameters = {
                    new( "provider", json )
                }
            };
            using var reader = await cmd.ExecuteReaderAsync();
            await reader.ReadAsync();
            int? provid = (int?)reader["provid"];
            return provid;
        }
    }
}
