using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer.Request;
using CommonLayer.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstituencyController : ControllerBase
    {
        private readonly IConstituencyBL constituencyBL;

        public ConstituencyController(IConstituencyBL constituencyBL)
        {
            this.constituencyBL = constituencyBL;
        }

        [HttpPost]

        public async Task<IActionResult> AddConstituency( ConstitutencyRequest constitutencyRequest)
        {
            try
            {
                var adminId = HttpContext.User.Claims.First(c => c.Type == "AdminId").Value;

                var data = await constituencyBL.AddPartyBL(constitutencyRequest, adminId);
                if (data != null)
                {
                    return Ok(new { success = true, message = " Constituency Added", data });
                }
                else
                {
                    return BadRequest(new { success = false, message = " Constituency Fail To add  " });
                }

            }
            catch (Exception exception)
            {
                return BadRequest(new { success = false, message = exception.Message });
            }
        }

        [HttpPut]
        [Route("{partyId}")]
        public async Task<IActionResult> UpdateConstituency(int partyId, ConstituencyRequest constituencyRequest)
        {
            try
            {
                var adminId = HttpContext.User.Claims.First(c => c.Type == "AdminId").Value;

                var data = await constituencyBL.UpdateConstituencyBL(partyId, constituencyRequest, adminId);

                if (data != null)
                {
                    return Ok(new { success = true, message = "Successfully updated Constituency", data });
                }
                else
                {
                    return BadRequest(new { success = false, message = " Constituency Update Failed " });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { success = false, message = exception.Message });
            }
        }

        [HttpDelete]
        [Route("{PartyId}")]
        public async Task<IActionResult> DeleteConstituency(int ConstituencyId)
        {
            try
            {
                var adminId = HttpContext.User.Claims.First(c => c.Type == "AdminId").Value;

                var data = await constituencyBL.DeleteConstituencyBL(ConstituencyId, adminId);

                if (data == true)
                {
                    return Ok(new { success = true, message = "Constituency Deleted" });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Constituency Fail To Delete" });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { success = false, message = exception.Message }); ;
            }
        }

        [HttpGet]
        public IActionResult GetConstituencies()
        {
            try
            {
                var adminId = HttpContext.User.Claims.First(c => c.Type == "AdminId").Value;

                IList<ConstituencyResponse> data = this.constituencyBL.GetConstituencyBL(adminId);

                if (data.Count != 0)
                {
                    return Ok(new { success = true, message = "All Parties Displayed", data });
                }
                else
                {
                    return Ok(new { success = false, message = " No Available Parties " });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { success = false, message = exception.Message });
            }
        }

    }
}