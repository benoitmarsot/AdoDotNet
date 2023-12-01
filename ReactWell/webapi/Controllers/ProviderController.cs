using domain;
using Microsoft.AspNetCore.Mvc;
using repository;
using System.Net;

namespace webapi.Controllers;
[ApiController]
[Route("api/pro")]
public class ProviderController : ControllerBase {
    private readonly IProviderRepository _providerRep;
    public ProviderController(IProviderRepository provider) {
        _providerRep = provider;
    }
    [HttpGet("assessment")]
    public async Task<ActionResult<Assessment>> GetAssessment(int providerId, int patientId) {
        Assessment? assessment = await _providerRep.GetAssessment(providerId, patientId);
        return Ok(assessment);
    }
    [HttpPut("assessment")]
    public async Task<ActionResult<int>> PutAssessment(
        int providerId, int patitientId, Assessment assessment
    ) {
        int? assessmentVersion = await _providerRep.SaveAssessment(providerId, patitientId, assessment);
        return Ok(assessmentVersion);
    }
    [HttpPost("register")]
    public async Task<ActionResult<int>> Register(
        Provider provider
    ) {
        int? providerId = await _providerRep.Register(provider);
        return Ok(providerId);
    }
    [HttpPost("signin")]
    //[ValidateAntiForgeryToken]  :to look at
    public async Task<ActionResult<Provider>> Signin(
        Credential credential
    ) {
        Provider? provider = await _providerRep.Signin(credential);
        if(provider == null) {
            return Unauthorized();
        }
        return Ok(provider);
    }
    [HttpPost("registerpatient")]
    public async Task<ActionResult<int>> RegisterPatient(
        int providerId, Patient patient
    ) {
        int? newPatientId = await _providerRep.RegisterPatient(providerId,patient);
        return Ok(newPatientId);
    }
    //Update provider info
    [HttpPut("update")] 
    public async Task<ActionResult<int>> UpdateProvider(
               Provider provider
           ) {
        int? providerId = await _providerRep.UpdateProvider(provider);
        return Ok(providerId);
    }

}
