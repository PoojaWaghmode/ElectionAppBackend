using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminBL adminBL;

        public AdminController( IAdminBL adminBL)
        {
            this.adminBL = adminBL;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> AdminRegistration(RegistrationModel registrationModel)
        {
            try
            {
             
                var data = await adminBL.AdminRegisterBL(registrationModel);

                
                if (!data.Equals(null))
                {
                    return Ok(new { status = true, message = "Register Succesfully", data });
                }
                else
                {
                  
                    return BadRequest(new { status = false, message = "Registartion Failed" });
                }
            }
            catch (Exception exception)
            {
              
                return BadRequest(new { success = false, message = exception.Message });
            }
        }

        [HttpPost]
        [Route("login")]
     
        public async Task<IActionResult> AdminLogin(LoginModel loginModel)
        {
            try
            {
                
                var data = await this.adminBL.AdminLoginBL(loginModel);

                if (data != null)
                {

                    var token = await this.adminBL.GenerateToken(data);

                  
                    return Ok(new { status = true, message = "Login Successfully", token, data });
                }
                else
                {
                   
                    return BadRequest(new { status = false, message = "Login Failed..Token Not Generated..Plz Input Valid Crediantials" });
                }
            }
            catch (Exception exception)
            {
               
                return BadRequest(new { success = false, message = exception.Message });
            }
        }

    }
}