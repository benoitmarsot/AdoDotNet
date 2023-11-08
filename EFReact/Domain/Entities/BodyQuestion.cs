
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities;
[Table("bodyquestion")]
public class BodyQuestion {
    //[Column("bodyquestionid", Order =0)]
    public long bodyquestionid {  get; set; }
    //[Column("assessmentid",Order=1)]
    public long assessmentid { get; set; }
    //[Column("x", Order = 2)]
    public double x { get; set; }
    //[Column("y", Order = 3)]
    public double y { get; set; }

    public ICollection<BodyQuestionText>? VersionTexts { get; set; }

    [JsonIgnore]  //prevent recurssion
    public Assessment? Assessment { get; set; }


}