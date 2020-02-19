using CommonLayer.Model;
using CommonLayer.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
     public interface IAdminRL
     {
        Task<AccountResponse> AdminRegisterRL(RegistrationModel registrationModel);

        Task<AccountResponse> AdminLoginRL(LoginModel loginModel);

        Task<string> GenerateToken(AccountResponse accountResponse);
    }
}
