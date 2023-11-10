using domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository;
public interface IProviderRepository {
    Task<Assessment?> GetAssessment(int providerId, int patientId);
    Task<int?> SaveAssessment(int providerId, int patientId, Assessment assessment);
    Task<int?> Register(Provider provider);
    Task<Provider?> Signin(Credential credential);
    Task<int?> RegisterPatient(int providerId, Patient patient);
    Task<int?> UpdateProvider(Provider provider);
}
