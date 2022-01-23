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
    public class IndividualRepository : SchoolAppDbContextBase<Individual, VW_Individual>, IIndividualRepository
    {
        protected override Individual AddEntity(SchoolAppDbContext entityContext, Individual entity)
        {
            return entityContext.IndividualSet.Add(entity).Entity;
        }

        protected override IEnumerable<Individual> GetEntities(SchoolAppDbContext entityContext)
        {
            return (from e in entityContext.IndividualSet
                    select e);
        }

        protected override Individual GetEntity(SchoolAppDbContext entityContext, int id)
        {
            return (from e in entityContext.IndividualSet
                    where e.IndividualId == id
                    select e).SingleOrDefault();
        }

        protected override Individual GetEntity(SchoolAppDbContext entityContext, Guid guid)
        {
            return (from e in entityContext.IndividualSet
                    where e.IndividualGuid == guid
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<VW_Individual> GetViewEntities(SchoolAppDbContext entityContext, IndividualSearch filter)
        {
            if (!string.IsNullOrEmpty(filter.Name))
            {
                return (from e in entityContext.IndividualVWSet
                        where e.Name.ToLower() == filter.Name.ToLower()
                        select e);
            }

            return (from e in entityContext.IndividualVWSet
                    select e);
        }

        protected override VW_Individual GetViewEntity(SchoolAppDbContext entityContext, IndividualSearch filter)
        {
            if (!string.IsNullOrEmpty(filter.Name))
            {
                return (from e in entityContext.IndividualVWSet
                        where e.Name.ToLower() == filter.Name.ToLower()
                        select e).FirstOrDefault();
            }

            return (from e in entityContext.IndividualVWSet
                    select e).FirstOrDefault();
        }

        protected override VW_Individual GetViewEntity(SchoolAppDbContext entityContext, int id)
        {
            return (from e in entityContext.IndividualVWSet
                    where e.IndividualId==id
                    select e).FirstOrDefault();
        }

        protected override VW_Individual GetViewEntity(SchoolAppDbContext entityContext, Guid guid)
        {
            return (from e in entityContext.IndividualVWSet
                    where e.IndividualGuid == guid
                    select e).FirstOrDefault();
        }

        protected override Individual UpdateEntity(SchoolAppDbContext entityContext, Individual entity)
        {
            return (from e in entityContext.IndividualSet
                    where e.IndividualId == entity.IndividualId
                    select e).FirstOrDefault();
        }
    }
}
