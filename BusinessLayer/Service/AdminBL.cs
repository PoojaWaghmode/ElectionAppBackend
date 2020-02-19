using BusinessLayer.Interface;
using CommonLayer.Model;
using CommonLayer.Response;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class AdminBL :IAdminBL
    {
        private readonly IAdminRL adminRL;

        public AdminBL(IAdminRL adminRL)
        {
            this.adminRL = adminRL;
        }

       

        public async Task<AccountResponse> AdminRegisterBL(RegistrationModel registrationModel)
        {
            try
            {
                if (registrationModel != null)
                {
                    
                    return await adminRL.AdminRegisterRL(registrationModel);
                }
                else
                {
                    throw new Exception("Model Have No Info");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<AccountResponse> AdminLoginBL(LoginModel loginModel)
        {
            try
            {
              
                if (!loginModel.Equals(null))
                {
                     return await this.adminRL.AdminLoginRL(loginModel);
                }
                else
                {
                    throw new Exception("No Info");
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }


        public async Task<string> GenerateToken(AccountResponse accountResponse)
        {
            try
            {
                if (accountResponse != null)
                {
                    return await adminRL.GenerateToken(accountResponse);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
