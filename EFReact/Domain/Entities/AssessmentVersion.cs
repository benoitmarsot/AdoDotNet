using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities;

[Table("assessmentversion")]
public class AssessmentVersion {
    [Key]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("assessmentversionid", Order = 0)]
    public long AssementVersionId { get; set; }
    [Column("assessmentid", Order=1)]
    public long? AssessmentId {  get; set; }
    [Column("note", Order = 2)]
    public string? Note { get; set; }
    [Column("servicedate", TypeName="Date", Order = 3)]
    public DateOnly? ServiceDate { get; set; }

    //public long providerid { get; set; }
    //public long patientid { get; set; }
    public ICollection<BodyQuestionText>? VersionTexts { get; set; }

    [JsonIgnore]  //prevent recurssion
    public Assessment? Assessment { get; set; }

    //public List<assessmentversion>? AssessmentVersions { get; set; }
    //public List<bodyquestion>? BodyQuestions { get; set; }

    //public AssessmentVersion(long assessmentId, long providerId, long patientId, List<AssessmentVersion> assessmentVersions, List<BodyQuestion> bodyQuestions) {
    //    AssessmentId = assessmentId;
    //    ProviderId = providerId;
    //    PatientId = patientId;
    //    AssessmentVersions = assessmentVersions;
    //    BodyQuestions = bodyQuestions;
    //}
}