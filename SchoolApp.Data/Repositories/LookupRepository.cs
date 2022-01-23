using SchoolApp.Business.Entities;
using SchoolApp.Data.Contracts.Interface;
using SchoolApp.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Data.Repositories
{
    public class LookupRepository : ILookupRepository
    {
        SchoolAppDbContext ctx;
        public LookupRepository()
        {
            ctx = new SchoolAppDbContext();
        }
        public IEnumerable<Country> GetCountries()
        {
            return (from e in ctx.CountrySet select e);
        }

        public IEnumerable<Education> GetEducations()
        {
            return (from e in ctx.EducationSet select e);
        }
    }
}
