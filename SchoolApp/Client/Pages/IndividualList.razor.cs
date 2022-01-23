using Microsoft.AspNetCore.Components;
using SchoolApp.Client.Contracts;
using SchoolApp.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.Client.Pages
{
    public partial class IndividualList
    {
        [Inject]
        public ISchoolService _schoolService { get; set; }
        public List<VW_Individual> Individuals { get; set; } = new List<VW_Individual>();
        public List<Country> Countries { get; set; } = new List<Country>();
        public IndividualSearch _filter { get; set; } = new IndividualSearch();
        protected async override Task OnInitializedAsync()
        {
            //return base.OnInitializedAsync();

            await loadData();
        }

        private async Task loadData()
        {
            Countries = (await _schoolService.GetAllCountries()).ToList();

            Individuals = (await _schoolService.GetAllIndividualVW(new IndividualSearch())).ToList();
        }
        public async Task DeleteIndividual(Guid? individualGuid)
        {
            await _schoolService.DeleteIndividual((Guid)individualGuid);
            Individuals = (await _schoolService.GetAllIndividualVW(_filter)).ToList();
        }

        public async Task OnSearch()
        {
            Individuals = (await _schoolService.GetAllIndividualVW(_filter)).ToList();
        }

    }
}
