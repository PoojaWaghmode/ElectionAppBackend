using CommonLayer.Model;
using CommonLayer.Request;
using CommonLayer.Response;
using Microsoft.AspNetCore.Identity;
using RepositoryLayer.Context;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class ConstituencyRL : IConstituencyRL
    {
        private readonly UserManager<AdminModel>userManager;

        private readonly AuthenticationContext authenticationContext;
        public ConstituencyRL( UserManager<AdminModel> userManager , AuthenticationContext authenticationContext)
        {
            this.userManager = userManager;
            this.authenticationContext = authenticationContext;

        }

        public async Task<ConstituencyResponse> AddConstituencyRL(ConstituencyRequest constituencyRequest, string adminId)
        {
            try
            {
                var newConstituency = new ConstituencyModel()
                {
                    ConstituencyName = constituencyRequest.ConstituencyName,
                    City = constituencyRequest.City,
                    State = constituencyRequest.State,
                    CreatedDate = DateTime.Now,
                    MofifiedDate = DateTime.Now

                };
                authenticationContext.Add(newConstituency);
                await this.authenticationContext.SaveChangesAsync();

                if (newConstituency != null)
                {
                    var constituencyResponse = new ConstituencyResponse()
                    {
                        ConstituencyId = newConstituency.Id,
                        ConstituencyName = newConstituency.ConstituencyName,
                        City = newConstituency.City,
                        State = newConstituency.State

                    };
                    return constituencyResponse;
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

        public Task<bool> DeleteConstituencyRL(int constituencyId, string adminId)
        {
            throw new NotImplementedException();
        }

        public IList<ConstituencyResponse> GetConstituenciesRL(string adminId)
        {
            throw new NotImplementedException();
        }

        public Task<ConstituencyResponse> UpdateConstituencyRL(ConstituencyRequest constituencyRequest, string adminId)
        {
            throw new NotImplementedException();
        }
    }
}
