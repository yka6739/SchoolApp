using Microsoft.AspNetCore.Components;
using SchoolApp.Client.Contracts;
using SchoolApp.Client.Entities;
using SchoolApp.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.Client.Pages
{
    public partial class AddEditIndividual
    {
        [Inject]
        public NavigationManager _navigationManager { get; set; }

        [Inject]
        public ISchoolService _schoolService { get; set; }

        public Individual ObjStudent { get; set; } = new Individual();

        public List<Education> _educationType { get; set; } = new List<Education>();
        public List<Country> _countryName { get; set; } = new List<Country>();


        [Parameter]
        public string IndividualGuid { get; set; }

        protected async override Task OnInitializedAsync()
        {

            _educationType = (await _schoolService.GetAllEducations()).ToList();
            _countryName = (await _schoolService.GetAllCountries()).ToList();


            if (!string.IsNullOrEmpty(IndividualGuid))
            {
                ObjStudent = await _schoolService.GetIndividualByGuid(new Guid(IndividualGuid));
            }
            // return base.OnInitializedAsync();
        }

        public async Task HandleValidSubmit()
        {
            if (ObjStudent.IndividualId == 0)
            {
                ObjStudent.CreateDate = DateTime.Now;
                ObjStudent.IndividualGuid = Guid.NewGuid();

            }
            ObjStudent.ModifiedDate = DateTime.Now;
            await _schoolService.Save(ObjStudent);
            _navigationManager.NavigateTo("/IndividualList");

        }

        public void HandleInvalidSubmit()
        {

        }
        public void OnCancleClick()
        {
            _navigationManager.NavigateTo("/IndividualList");
        }

    }
}
