namespace ReactWellNet.domain;

public class BodyQuestion {
    public long BodyQuestionId {  get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public List<BodyQuestionText> VersionTexts { get; set; }

    //public BodyQuestion(long bodyQuestionId, float x, float y, List<BodyQuestionText> versionTexts) {
    //    BodyQuestionId = bodyQuestionId;
    //    X = x;
    //    Y = y;
    //    VersionTexts = versionTexts;
    //}
}