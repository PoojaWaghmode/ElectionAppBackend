using CommonLayer.Model;
using CommonLayer.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IAdminBL
    {

        Task<AccountResponse> AdminRegisterBL(RegistrationModel registrationModel);

        Task<AccountResponse> AdminLoginBL(LoginModel loginModel);

        Task<string> GenerateToken(AccountResponse accountResponse);
    }

}
