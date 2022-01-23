using SchoolApp.Client.Contracts;
using SchoolApp.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Client.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly IHttpService _httpService;

        public SchoolService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<bool> DeleteIndividual(Guid individualGuid)
        {
            return await _httpService.Get<bool>("api/school/DeleteIndividual/" + individualGuid);
        }

        //public async Task<bool> DeleteStudent(Guid individualGuid)
        //{
           
        //    throw new NotImplementedException();
        //}

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            return await _httpService.GetEntities<Country>("api/school/GetAllCountries");
        }

        public async Task<IEnumerable<Education>> GetAllEducations()
        {
            return await _httpService.GetEntities<Education>("api/school/GetAllEducations");
        }

        public async Task<IEnumerable<VW_Individual>> GetAllIndividualVW(IndividualSearch filter)
        {
            return await _httpService.GetFilteredEntities<VW_Individual>("api/school/GetFilteredIndividuals", filter);
        }

        public async Task<Individual> GetIndividualByGuid(Guid individualGuid)
        {
            return await _httpService.Get<Individual>("api/school/GetIndividualByGuid/" + individualGuid);
        }

        public async Task<Individual> Save(Individual individual)
        {
            return await _httpService.Post<Individual>("api/school/SaveIndividual", individual);
        }
    }
}
