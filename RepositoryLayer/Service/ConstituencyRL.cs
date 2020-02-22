using CommonLayer.Model;
using CommonLayer.Request;
using CommonLayer.Response;
using Microsoft.AspNetCore.Identity;
using RepositoryLayer.Context;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    ModifiedDate = DateTime.Now

                };
                authenticationContext.Constituencies.Add(newConstituency);

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

        public async  Task<bool> DeleteConstituencyRL(int constituencyId, string adminId)
        {
            try
            {
                var constituencyData = this.authenticationContext.Constituencies.Where(p => p.Id == constituencyId).FirstOrDefault();

                if (constituencyData != null)
                {
                    this.authenticationContext.Remove(constituencyData);

                    await this.authenticationContext.SaveChangesAsync();

                    return true;
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

        public IList<ConstituencyResponse> GetConstituenciesRL(string adminId)
        {
           try
            {
                var constituencyData = this.authenticationContext.Constituencies.Select(s=>s);
                if(constituencyData !=null)
                {
                    var allConstituencyDatalist = new List<ConstituencyResponse>();
                    foreach( var constituency in allConstituencyDatalist)
                    {
                        allConstituencyDatalist.Add(constituency);
                    }
                    return allConstituencyDatalist;
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

        public async Task<ConstituencyResponse> UpdateConstituencyRL(int constituencyId ,ConstituencyRequest constituencyRequest, string adminId)
        {
           try
            {
                var constituencyData = this.authenticationContext.Constituencies.Where(s => s.Id == constituencyId && s.ConstituencyName != constituencyRequest.ConstituencyName || s.City != constituencyRequest.City || s.State != constituencyRequest.State).FirstOrDefault();
                if(constituencyData!=null)
                {
                    if(constituencyRequest.ConstituencyName != null && constituencyRequest.ConstituencyName !=string .Empty)
                    {
                        constituencyData.ConstituencyName= constituencyRequest.ConstituencyName;
                    }
                    if(constituencyRequest.City !=null && constituencyRequest.City != string.Empty)
                    {
                        constituencyData.City = constituencyRequest.City;
                    }
                    if(constituencyRequest.State != null && constituencyRequest.State != string.Empty)
                    {
                        constituencyData.State = constituencyRequest.State;
                    }
                    constituencyData.ModifiedDate = DateTime.Now;

                    await this.authenticationContext.SaveChangesAsync();

                    var constituencyResponse = new ConstituencyResponse()
                    {
                        ConstituencyId=constituencyData.Id,
                        ConstituencyName=constituencyData.ConstituencyName,
                        City=constituencyData.City,
                        State=constituencyData.State

                    };
                    return constituencyResponse;

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
    }
}
