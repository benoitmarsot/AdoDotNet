using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using DataAcess.EFCore;
using Microsoft.EntityFrameworkCore;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ApplicationContext _context;
    public WeatherForecastController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        Provider pr = _context.Providers
//            .Include(pr=>pr.Patients)
            .FirstOrDefault();
        Patient p =_context.Patients
            .Include(pa => pa.Providers)
            .FirstOrDefault();

        //ProviderPatient pp = _context.ProviderPatients.FirstOrDefault();
        Assessment a = _context.Assessments
            .Include(av => av.AssessmentVersions)
            .Include(bq => bq.BodyQuestions)
            .ThenInclude(av => av.VersionTexts)
            .FirstOrDefault();
        AssessmentVersion avs = _context.AssessmentVersions.FirstOrDefault();
        BodyQuestion bq =_context.BodyQuestions.FirstOrDefault();   
        BodyQuestionText bqt=_context.BodyQuestionTexts.FirstOrDefault();

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
    //[HttpGet(Name = "ShowPatient")]
    //public Patient GetPatient() {
    //    return _context.Patients.Find(1);
    //}

}
