using Microsoft.AspNetCore.Mvc;
using ReactWellNet.domain;
using ReactWellNet.Repository;

namespace ReactWellNet.Controllers;
public class ApiController : Controller {
    private readonly IPatientRepository _patientRep;

    public ApiController(IPatientRepository patient) {
        _patientRep = patient;
    }
    public IActionResult Index() {
        return View();
    }

    [HttpGet()]
    public async Task<ActionResult<Patient>> GetPatient(int patientId) {
        Patient? p = await _patientRep.GetPatient(patientId);
        return p;

    }
}
