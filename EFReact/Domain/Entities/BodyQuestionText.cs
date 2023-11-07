using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using System.Text.Json.Serialization;

namespace Domain.Entities;
//EF 7 ways
//[PrimaryKey(nameof(BodyQuestionId), nameof(AssessmentVersionId))]
[Table("bodyquestiontext")]
public class BodyQuestionText {
    //Do not works  on EF Core anymore
    //[Key]
    [Column("bodyquestionid", Order = 0)]
    public long BodyQuestionId { get; set; }
    //[Key]
    [Column("assessmentversionid", Order = 1)]
    public long AssessmentVersionId {  get; set; }
    [Column("questiontext", Order = 2)]
    public string? QuestionQext { get; set; }

    [JsonIgnore]  //prevent recurssion
    public BodyQuestion? BodyQuestion { get; set; }

    [JsonIgnore]  //prevent recurssion
    public AssessmentVersion? AssessmentVersion { get; set; }

}