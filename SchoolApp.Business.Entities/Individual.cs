using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Business.Entities
{
    public class Individual
    {
        public int IndividualId { get; set; }

        public string Name { get; set; }

        public DateTime DoB { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int? EducationId { get; set; }

        public int? CountryId { get; set; }

        public int? WorkExprience { get; set; }

        public Guid? IndividualGuid { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
