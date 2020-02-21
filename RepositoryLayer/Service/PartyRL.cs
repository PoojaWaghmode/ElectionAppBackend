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
    public class PartyRL : IPartyRL
    {
        private readonly UserManager<AdminModel> userManager;

        private readonly AuthenticationContext authenticationContext;

      
        public PartyRL(UserManager<AdminModel> userManager, AuthenticationContext authenticationContext)
        {
            this.userManager = userManager;
            this.authenticationContext = authenticationContext;
        }

        public async Task<PartyResponse> AddPartyRL(PartyRequest partyRequest, string adminId)
        {
            try
            {
                var newParty = new PartyModel()
                {
                    PartyName = partyRequest.PartyName,
                    RegisteredBy = partyRequest.RegisterBy,
                    CreatedDate = DateTime.Now,
                    MofifiedDate = DateTime.Now

                };
                authenticationContext.Add(newParty);
                await this.authenticationContext.SaveChangesAsync();

                if(newParty !=null)
                {
                    var partyResponse = new PartyResponse()
                    {
                        Id = newParty.Id,
                        PartyName = newParty.PartyName,
                        RegisteredBy = newParty.RegisteredBy

                    };
                    return partyResponse;
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

        public async  Task<PartyResponse> UpdatePartyRL(int PartyId, PartyRequest partyRequest, string adminId)
        {
           try
            {
                var partyData = this.authenticationContext.Parties.Where(c => c.Id == PartyId && c.PartyName !=partyRequest.PartyName ).FirstOrDefault();
                if(partyData !=null)
                {
                    if(partyRequest.PartyName !=null && partyRequest.PartyName !=string.Empty)
                    {
                        partyData.PartyName = partyRequest.PartyName;
                    }
                    if(partyRequest.RegisterBy !=null && partyRequest.RegisterBy !=string.Empty)
                    {
                        partyData.RegisteredBy = partyRequest.RegisterBy;
                    }
                    partyData.MofifiedDate = DateTime.Now;

                    await this.authenticationContext.SaveChangesAsync();

                    var partyResponse = new PartyResponse()
                    {
                        Id = partyData.Id,
                        PartyName = partyData.PartyName,
                        RegisteredBy = partyData.RegisteredBy
                    };
                    return partyResponse;
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

        public async Task<bool> DeletePartyRL(int PartyId, string adminId)
        {
           try
            {
                var partyData = this.authenticationContext.Parties.Where(p => p.Id == PartyId).FirstOrDefault();
                if(partyData !=null)
                {
                    this.authenticationContext.Remove(partyData);

                    await this.authenticationContext.SaveChangesAsync();

                    return true;
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

        public IList<PartyResponse> GetPartiesRL(string adminId)
        {
           try
            {
              
                var partyData = this.authenticationContext.Parties.Select(s=>s);

                
                if(partyData!=null)
                {
                    var allpartyData = new List<PartyResponse>();

                    foreach (var party in partyData)
                    {
                        var data = new PartyResponse()
                        {
                            Id = party.Id,
                            PartyName = party.PartyName,
                            RegisteredBy = party.RegisteredBy
                        };

                        allpartyData.Add(data);
                    }
                    return allpartyData;
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
    }
}
