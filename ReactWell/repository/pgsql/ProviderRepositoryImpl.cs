using domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository.pgsql;
public class ProviderRepositoryImpl : IProviderRepository {
    public Task<Assessment> GetAssessment(int providerId, int patientId) {
        throw new NotImplementedException();
    }

    public Task<int> Register(Provider provider) {
        throw new NotImplementedException();
    }

    public Task<int> RegisterPatient(int providerId, Patient patient) {
        throw new NotImplementedException();
    }

    public Task<int> SaveAssessment(int providerId, int patientId, Assessment assessment) {
        throw new NotImplementedException();
    }

    public Task<Provider> Signin(Credential credential) {
        throw new NotImplementedException();
    }

    public Task<int> UpdateProvider(Provider provider) {
        throw new NotImplementedException();
    }
}
