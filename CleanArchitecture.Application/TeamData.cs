using System;
using System.Net.Http;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using Newtonsoft.Json;

namespace CleanArchitecture.Application
{
    public interface ITeamUseCase
    {
        Task<Team> Get_BasketballTeamAsync(string locationId);
    }

    public class TeamUseCase : ITeamUseCase
    {
        private const string BaseUrl = "https://www.balldontlie.io/api/v1/teams/";
        public async Task<Team> Get_BasketballTeamAsync(string teamId)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"{BaseUrl}{teamId}";
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    var team = JsonConvert.DeserializeObject<Team>(res);
                    return team ?? new Team();
                }
                else
                {
                    new Team();
                }
            }

            return new Team(); 
        }
    }
}