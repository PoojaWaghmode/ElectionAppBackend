using CommonLayer.Request;
using CommonLayer.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IPartyRL
    {
        Task<PartyResponse> AddPartyRL(PartyRequest partyRequest , string adminId);

        Task<PartyResponse> UpdatePartyRL(int PartyId, PartyRequest partyRequest , string adminId);

        Task<bool> DeletePartyRL(int PartyId , string adminId);

        IList<PartyResponse> GetPartiesRL( string AdminId );
    }
}
