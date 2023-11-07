using System.Threading.Tasks;
using ReactWellNet.domain;

namespace ReactWellNet.Repository;
public interface IPatientRepository {
    //Task<int> updatePatient(int patientId, Patient patient);
    Task<Patient?> GetPatient(int patientId);
}
