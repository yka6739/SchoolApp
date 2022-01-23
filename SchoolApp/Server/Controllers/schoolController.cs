using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Business.Entities;
using SchoolApp.Data.Contracts.Interface;
using System;
using System.Collections.Generic;

namespace SchoolApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class schoolController : ControllerBase
    {
        private readonly IIndividualRepository _individualRepository;
        private readonly ILookupRepository _lookupRepository;
        public schoolController(IIndividualRepository individualRepository, ILookupRepository lookupRepository)
        {
            _individualRepository=individualRepository;
            _lookupRepository = lookupRepository;
        }
        [HttpPost("GetFilteredIndividuals")]
        public IEnumerable<VW_Individual>GetIndividuals(IndividualSearch filter)
        {
            return _individualRepository.GetVwEntities(filter);
        }
        [HttpGet("GetIndividualByGuid/{individualGuid}")]
        public VW_Individual GetIndividuals(Guid individualGuid)
        {
            return _individualRepository.GetVwEntity(individualGuid);
        }
        [HttpPost("SaveIndividual")]
        public Individual SaveIndividual(Individual individual)
        {

            if (individual.IndividualId == 0)
            {
                return _individualRepository.Add(individual);
            }
            else
            {
                return _individualRepository.Update(individual);
            }

        }

        [HttpGet("GetAllCountries")]
        public IEnumerable<Country> GetAllCountries()
        {

            return _lookupRepository.GetCountries();
        }
        [HttpGet("GetAllEducations")]
        public IEnumerable<Education> GetAllEducations()
        {

            return _lookupRepository.GetEducations();
        }
        [HttpGet("RemoveStudent/{studentGuid}")]
        public bool DeleteStudent(Guid individualGuid)
        {
            try
            {
                _individualRepository.Remove(individualGuid);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }






        }
    }
}
