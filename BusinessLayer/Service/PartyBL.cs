using BusinessLayer.Interface;
using CommonLayer.Request;
using CommonLayer.Response;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class PartyBL : IPartyBL
    {
        private readonly IPartyRL partyRL;
        public PartyBL(IPartyRL partyRL)
        {
            this.partyRL = partyRL;
        }

        public async Task<PartyResponse> AddPartyBL(PartyRequest partyRequest , string adminId)
        {
            try
            {
                var result = await partyRL.AddPartyRL(partyRequest, adminId);
          
                if(result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception exception )
            {
                throw new Exception(exception.Message);
            }
        }
        public async Task<PartyResponse> UpdatePartyBL(int PartyId, PartyRequest partyRequest , string adminId)
        {
            
            try
            {
                var result = await partyRL.UpdatePartyRL(PartyId, partyRequest, adminId);

                if ( result !=null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch ( Exception exception)
            {
                throw new Exception ( exception.Message);
            }
        }

        public async Task<bool> DeletePartyBL(int PartyId, string adminId)
        {
           try
            {
                var result = await this.partyRL.DeletePartyRL(PartyId,adminId);
                if(result == true)
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public IList<PartyResponse> GetPartiesBL( string AdminId)
        {
           try
            {
                var result = partyRL.GetPartiesRL(AdminId);
                if(result.Count != 0)
                {
                    return result;
                }
                else
                {
                    return result;
                }
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

    }
}
