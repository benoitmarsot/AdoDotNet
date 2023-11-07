using System.Net;
using System.Threading.Tasks;
using ReactWellNet.domain;

namespace ReactWellNet.Repository;

public interface IProviderRepository {
    Task<Assessment> GetAssessment(int providerId, int patientId);
    Task<int> SaveAssessment(int providerId, int patientId, Assessment assessment);
    Task<int> Register(Provider provider);
    Task<Provider> Signin(Credential credential);
    Task<int> RegisterPatient(int providerId, Patient patient);
    Task<int> UpdateProvider(Provider provider);
}
