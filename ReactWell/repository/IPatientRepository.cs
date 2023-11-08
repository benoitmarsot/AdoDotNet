using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain;

namespace repository;
public interface IPatientRepository {
    Task<int?> updatePatient(int patientId, Patient patient);
    Task<Patient?> GetPatient(int patientId);
}
