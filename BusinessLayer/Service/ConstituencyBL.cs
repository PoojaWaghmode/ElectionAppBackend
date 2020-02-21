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
    public class ConstituencyBL : IConstituencyBL
    {
        private readonly IConstituencyRL constituencyRL;
        public ConstituencyBL(IConstituencyRL constituencyRL)
        {
            this.constituencyRL = constituencyRL;
        }

        public async Task<ConstituencyResponse> AddConstituencyBL(ConstituencyRequest constituencyRequest, string adminId)
        {
           try
            {
                var result = await constituencyRL.AddConstituencyRL(constituencyRequest, adminId);

                if( result !=null)
                {
                    return result;
                }
                else
                {
                    return null;
                }

            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }


        public async Task<ConstituencyResponse> UpdateConstituencyBL(ConstituencyRequest constituencyRequest, string adminId)
        {


            try
            {
                var result = await constituencyRL.UpdateConstituencyRL(constituencyRequest, adminId);

                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public IList<ConstituencyResponse> GetConstituenciesBL(string adminId)
        {
            try
            {
                var result = constituencyRL.GetPartiesRL(adminId);
                if (result.Count != 0)
                {
                    return result;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async  Task<bool> DeleteConstituencyBL(int constituencyId, string adminId)
        {
            try
            {
                var result = await this.constituencyRL.DeletePartyRL(constituencyId, adminId);

                if (result == true)
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
