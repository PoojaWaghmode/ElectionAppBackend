using CommonLayer.Request;
using CommonLayer.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IPartyBL
    {
        Task <PartyResponse> AddPartyBL(PartyRequest partyRequest ,string adminId);

        Task <PartyResponse> UpdatePartyBL(int PartyId, PartyRequest partyRequest, string adminId);

        Task<bool> DeletePartyBL(int PartyId, string adminId);

        IList<PartyResponse> GetPartiesBL( string adminId );

    }
}
