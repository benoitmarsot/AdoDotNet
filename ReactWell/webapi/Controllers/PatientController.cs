using domain;
using Microsoft.AspNetCore.Mvc;
using repository;

namespace webapi.Controllers;
[ApiController]
[Route("api/patient")]
public class PatientController : ControllerBase {
    private readonly IPatientRepository _patientRep;
    public PatientController(IPatientRepository patient) {
        _patientRep = patient;
    }
    [HttpGet("getpatient")]
    public async Task<ActionResult<Patient>> GetPatient(int patientId) {
        Patient? p = await _patientRep.GetPatient(patientId);
        return Ok(p);
    }
    [HttpPost("updatepatient")]
    public async Task<ActionResult<int?>> updatePatient(
        int patientId, Patient patient
    ) {
        int? pid=await _patientRep.updatePatient(patientId,patient);  
        return Ok(pid);

    }
}
