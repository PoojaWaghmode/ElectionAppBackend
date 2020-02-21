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
    public class PartyController : ControllerBase
    {
        private readonly IPartyBL partyBL;

        public PartyController(IPartyBL partyBL)
        {
            this.partyBL = partyBL;
        }

        [HttpPost]
       
        public async Task<IActionResult> AddParty(PartyRequest partyRequest)
        {
            try
            {
                var adminId = HttpContext.User.Claims.First(c => c.Type == "AdminId").Value;

                var data = await partyBL.AddPartyBL(partyRequest, adminId);
                if (data != null)
                {
                    return Ok(new { success = true, message = " Party Added", data });
                }
                else
                {
                    return BadRequest(new { success = false, message = " Party Fail To add  " });
                }

            }
            catch (Exception exception)
            {
                return BadRequest(new { success = false, message = exception.Message });
            }
        }

        [HttpPut]
        [Route("{partyId}")]
        public async Task<IActionResult> UpdateParty(int partyId, PartyRequest partyRequest)
        {
            try
            {
                var adminId = HttpContext.User.Claims.First(c => c.Type == "AdminId").Value;

                var data = await partyBL.UpdatePartyBL(partyId, partyRequest, adminId);

                if (data != null)
                {
                    return Ok(new { success = true, message = "Successfully updated Party", data });
                }
                else
                {
                    return BadRequest(new { success = false, message = " Party Update Failed " });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { success = false, message = exception.Message });
            }
        }

        [HttpDelete]
        [Route ("{PartyId}" )]
        public async Task <IActionResult> DeleteParty(int PartyId)
        {
            try
            {
                var adminId = HttpContext.User.Claims.First(c => c.Type == "AdminId").Value;

                var data = await partyBL.DeletePartyBL(PartyId , adminId);

                if(data == true)
                {
                    return Ok(new { success = true, message = "Party Deleted" });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Party Fail To Delete" });
                }
            }
            catch(Exception exception)
            {
                return BadRequest(new { success = false ,message = exception.Message}); ;
            }
        }

        [HttpGet]
        public IActionResult GetParties()
        {
            try
            {
                var adminId = HttpContext.User.Claims.First(c => c.Type == "AdminId").Value;

                IList <PartyResponse> data = this. partyBL.GetPartiesBL(adminId);

                if(data.Count != 0)
                {
                    return Ok(new { success = true, message = "All Parties Displayed", data });
                }
                else
                {
                    return Ok(new { success = false, message = " No Available Parties " });
                }
            }
            catch(Exception exception)
            {
                return BadRequest(new { success = false, message = exception.Message });
            }
        }
    }
}