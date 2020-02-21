using CommonLayer.Response;
using CommonLayer.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{

    public interface IConstituencyBL
    {
        Task <ConstituencyResponse> AddConstituencyBL(ConstituencyRequest constituencyRequest, string adminId);

        Task<bool> DeleteConstituencyBL(int constituencyId, string adminId);

        Task<ConstituencyResponse> UpdateConstituencyBL( ConstituencyRequest constituencyRequest ,string adminId);

        IList<ConstituencyResponse> GetConstituenciesBL( string adminId);
    }
}
