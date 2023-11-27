using domain;

namespace repository;
public interface IPatientRepository {
    Task<int?> UpdatePatient(int patientId, Patient patient);
    Task<Patient?> GetPatient(int patientId);
}
