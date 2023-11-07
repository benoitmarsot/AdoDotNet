namespace ReactWellNet.domain;

public class Patient {
    public long patientId {  get; set; }
    public long userId { get; set; }
    public string firstName {  get; set; }
    public string lastName { get; set; }
    public string address { get; set; }
    public string city { get; set; }
    public string usState { get; set; }
    public string zip { get; set; }
    public string referral { get; set; }
    public string email { get; set; }
    public string password { get; set; }

    //public Patient(long patientId, long userId, string firstName, string lastName, string address, string city, string usState, string zip, string referral, string email, string password) {
    //    PatientId = patientId;
    //    UserId = userId;
    //    FirstName = firstName;
    //    LastName = lastName;
    //    Address = address;
    //    City = city;
    //    UsState = usState;
    //    Zip = zip;
    //    Referral = referral;
    //    Email = email;
    //    Password = password;
    //}
}
