using SchoolApp.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Client.Contracts
{
    public interface ISchoolService
    {
        Task<IEnumerable<VW_Individual>> GetAllIndividualVW(IndividualSearch filter);
        Task <Individual>Save(Individual individual);
        Task<Individual> GetIndividualByGuid(Guid individualGuid);
        Task<bool> DeleteIndividual(Guid individualGuid);
        //Task<bool> DeleteStudent(Guid individualGuid);
        Task<IEnumerable<Country>> GetAllCountries();
        Task<IEnumerable<Education>> GetAllEducations();
    }
}
