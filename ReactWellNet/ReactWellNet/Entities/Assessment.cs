namespace ReactWellNet.domain;

public class Assessment {
    public long AssessmentId { get; set; }
    public long ProviderId { get; set; }
    public long PatientId { get; set; }
    public List<AssessmentVersion> AssessmentVersions { get; set; }
    public List<BodyQuestion> BodyQuestions { get; set; }

    //public Assessment(long assessmentId, long providerId, long patientId, List<AssessmentVersion> assessmentVersions, List<BodyQuestion> bodyQuestions) {
    //    AssessmentId = assessmentId;
    //    ProviderId = providerId;
    //    PatientId = patientId;
    //    AssessmentVersions = assessmentVersions;
    //    BodyQuestions = bodyQuestions;
    //}
}
