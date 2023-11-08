using domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository;
public interface IRWUserRepository {
    Task<RWUser> RegisterUser(string demoUserName, string oktaClientId);
    Task<RWUser> FindByUserName(string demoUserName);
    Task<RWUser> FindByOktaClientId(string DemoUserName, string oktaClientId);
    Task<int> CountUser();
}

