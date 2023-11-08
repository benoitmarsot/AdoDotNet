using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities;
[Table("patient")]
public class Patient {
    [Key]
    [Column("patientid",Order =0)]
    public long PatientId {  get; set; }
    [Column("rwuserid", Order = 1)]
    public long UserId { get; set; }
    [Column("firstname", Order = 2)]
    public string? FirstName {  get; set; }
    [Column("lastname", Order = 3)]
    public string? LastName { get; set; }
    [Column("address", Order = 4)]
    public string? Address { get; set; }
    [Column("city", Order = 5)]
    public string? City { get; set; }
    [Column("usstate", Order = 6)]
    public string? UsState { get; set; }
    [Column("zip", Order = 7)]
    public string? Zip { get; set; }
    [Column("referral", Order = 8)]
    public string? Referral { get; set; }
    [JsonIgnore]
    public ICollection<Provider>? Providers { get; set; }


}
