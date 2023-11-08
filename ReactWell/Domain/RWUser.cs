using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain;
public class RWUser {
    public long? rwUserId { get; set; }
    public string? rwUserName { get; set; }
    public string? oktaClientId { get; set; }
    public string? email { get; set; }
}
