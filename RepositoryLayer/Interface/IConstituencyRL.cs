using CommonLayer.Request;
using CommonLayer.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IConstituencyRL
    {
        Task<ConstituencyResponse> AddConstituencyRL(ConstituencyRequest constituencyRequest, string adminId);

        Task<bool> DeleteConstituencyRL(int constituencyId, string adminId);

        Task<ConstituencyResponse> UpdateConstituencyRL(ConstituencyRequest constituencyRequest, string adminId);

        IList<ConstituencyResponse> GetConstituenciesRL(string adminId);
    }
}
