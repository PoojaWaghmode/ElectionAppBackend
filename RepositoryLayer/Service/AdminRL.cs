using CommonLayer.Model;
using CommonLayer.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Context;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public  class AdminRL :IAdminRL
    {
        private readonly UserManager<AdminModel> userManager;

        private readonly AuthenticationContext authenticationContext;

        private readonly IConfiguration configuration;
        public AdminRL( UserManager<AdminModel> userManager,AuthenticationContext authenticationContext,IConfiguration configuration)
        {
            this.userManager = userManager;
            this.authenticationContext = authenticationContext;
            this.configuration = configuration;

        }

        public async Task<AccountResponse> AdminRegisterRL(RegistrationModel registrationModel)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(registrationModel.Email);
                if (user == null)
                {

                    var adminInfo = new AdminModel()
                    {
                        UserName = registrationModel.UserName,
                        FirstName = registrationModel.FirstName,
                        LastName = registrationModel.LastName,
                        PhoneNumber = registrationModel.MobileNo,
                        Email = registrationModel.Email,
                      

                    };
                    var result = await userManager.CreateAsync(adminInfo, registrationModel.Password);
                   await this.authenticationContext.SaveChangesAsync();

                    if (result.Succeeded)
                    {
                        var showModel = new AccountResponse()
                        {

                            FirstName = adminInfo.FirstName,
                            LastName = adminInfo.LastName,
                            Mobile = adminInfo.PhoneNumber,
                            Email = adminInfo.Email,

                        };
                        return showModel;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    throw new Exception("Record Already Exist");
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

        }
        public async Task<AccountResponse> AdminLoginRL(LoginModel loginModel)
        {
            try
            {
                var admin = await userManager.FindByEmailAsync(loginModel.Email);


                bool result = await userManager.CheckPasswordAsync(admin, loginModel.Password);

                if (admin != null)
                {
                    var adminInfo = new AccountResponse()
                    {
                        FirstName=admin.FirstName,
                        LastName=admin.LastName,
                        Mobile=admin.PhoneNumber,
                        Email=admin.Email

                    };
                    return adminInfo;
                }
                else
                {

                    throw new Exception("Mail or password incorrect");
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

        }
        public async Task<string> GenerateToken(AccountResponse accountResponse)
        {
            var user = await userManager.FindByEmailAsync(accountResponse.Email);
            if (user != null)
            {
                ////Here generate encrypted key and result store in security key
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]));

                //// here using securitykey and algorithm(security) the creadintails is generate(SigningCredentials present in Token)
                var creadintials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[] {
                                    new Claim("UserId", user.Id.ToString()),
                                   new Claim("UserName", user.UserName.ToString())
                                   };
                var token = new JwtSecurityToken("Security token", "https://Test.com", claims, DateTime.UtcNow, expires: DateTime.Now.AddDays(5), signingCredentials: creadintials);
                JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                string generatedToken = jwtSecurityTokenHandler.WriteToken(token);
                return generatedToken;
            }
            else
            {
                return null;
            }
        }
    }
}
