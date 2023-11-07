using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("provider")]
public class Provider {
    [Key]
    [Column("providerid",Order =0 )]
    public long ProviderId {  get; set; }
    [Column("rwuserid", Order = 1)]
    public long? UserId { get; set; }
    //public List<Patient>? Patients { get; set; }
    [Column("firstname", Order = 2)]
    public string? FirstName { get; set; }
    [Column("lastname", Order = 3)]
    public string? LastName { get; set; }
    [Column("company", Order = 4)]
    public string? Company { get; set; }
    [Column("address", Order = 5)]
    public string? Address { get; set; }
    [Column("city", Order = 6)]
    public string? City { get; set; }
    [Column("usstate", Order = 7)]
    public string? UsState { get; set; }
    [Column("zip", Order = 8)]
    public string? Zip { get; set; }
    //public string? email { get; set; }
    //public string? password { get; set; }

    //public Provider(long providerId, long rwuserId, List<Patient> patients, string firstName, string lastName, string company, string address, string city, string usState, string zip, string email, string password) {
    //    ProviderId = providerId;
    //    RwuserId = rwuserId;
    //    Patients = patients;
    //    FirstName = firstName;
    //    LastName = lastName;
    //    Company = company;
    //    Address = address;
    //    City = city;
    //    UsState = usState;
    //    Zip = zip;
    //    Email = email;
    //    Password = password;
    //}
}
