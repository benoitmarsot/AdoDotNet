using System.Runtime.InteropServices;

namespace ReactWellNet.domain;

public class BodyQuestionText {
    public long? AssessmentVersionId {  get; set; }
    public string Content { get; set; }
    //public BodyQuestionText(long? assessmentVersionId, string content) {
    //    AssessmentVersionId = assessmentVersionId;
    //    Content = content;
    //}
}