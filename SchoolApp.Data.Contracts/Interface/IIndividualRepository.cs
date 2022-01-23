using Core.Common.Contracts;
using SchoolApp.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Data.Contracts.Interface
{
    public interface IIndividualRepository:ICoreRepository<Individual,VW_Individual, IndividualSearch>
    {
    }
}
