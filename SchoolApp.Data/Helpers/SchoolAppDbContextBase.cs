using Core.Common.Data;
using SchoolApp.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Data.Helpers
{
    public abstract class SchoolAppDbContextBase<T, VW> : CoreRepository<T, VW, IndividualSearch, SchoolAppDbContext>
       where T : class, new()
       where VW : class, new()
    {
    }
}
