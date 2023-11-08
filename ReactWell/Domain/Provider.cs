namespace domain;

public class Provider {
    public long? providerId {  get; set; }
    public long? rwuserId { get; set; }
    public List<Patient>? patients { get; set; }
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    public string? company { get; set; }
    public string? address { get; set; }
    public string? city { get; set; }
    public string? usState { get; set; }
    public string? zip { get; set; }
    public string? email { get; set; }
    public string? password { get; set; }


}
