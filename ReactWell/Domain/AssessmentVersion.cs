namespace domain;

public class AssessmentVersion {
    public long? assessmentId {  get; set; }
    public long? providerId { get; set; }
    public long? patientId { get; set; }
    public List<AssessmentVersion>? assessmentVersions { get; set; }
    public List<BodyQuestion>? bodyQuestions { get; set; }

}