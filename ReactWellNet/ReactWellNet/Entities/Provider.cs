namespace ReactWellNet.domain;

public class Provider {
    public long ProviderId {  get; set; }
    public long RwuserId { get; set; }
    public List<Patient> Patients { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string UsState { get; set; }
    public string Zip { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

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
