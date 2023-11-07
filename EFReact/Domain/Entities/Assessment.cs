using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("assessment")]
public class Assessment {
    [Column("assessmentid", Order=0)]
    public long AssessmentId { get; set; }
    [Column("providerid", Order = 1)]
    public long ProviderId { get; set; }
    [Column("patientid", Order = 2)]
    public long PatientId { get; set; }
    public ICollection<AssessmentVersion>? AssessmentVersions { get; set; }
    public ICollection<BodyQuestion>? BodyQuestions { get; set; }
}
