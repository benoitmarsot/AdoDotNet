using Microsoft.AspNetCore.Mvc;
using ReactWellNet.Models;
using System.Diagnostics;
using ReactWellNet.Repository;
using ReactWellNet.domain;

namespace ReactWellNet.Controllers;
public class HomeController : Controller {
    private readonly IPatientRepository _patientRep;

    public HomeController(IPatientRepository patient) {
        _patientRep = patient;
    }

    public IActionResult Index() {
        return View();
    }

    public IActionResult Privacy() {
        return View();
    }

    public async Task<IActionResult> ShowPatient() {
        Patient? p = await _patientRep.GetPatient(1);
        return View(p);

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
