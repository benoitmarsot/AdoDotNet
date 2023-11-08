namespace domain;

public class BodyQuestion {
    public long? bodyQuestionId {  get; set; }
    public float? x { get; set; }
    public float? y { get; set; }
    public List<BodyQuestionText>? versionTexts { get; set; }

}