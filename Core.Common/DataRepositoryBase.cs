using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System;
using Core.Common.Utils;
using Core.Common.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Core.Common.Data
{

    public abstract class DataRepositoryBase<T, U> : IDataRepository<T>
        where T : class,  new()
        where U : DbContext, new()
    {

     
        protected abstract T AddEntity(U entityContext, T entity);

        protected abstract T UpdateEntity(U entityContext, T entity);

        protected abstract IEnumerable<T> GetEntities(U entityContext);
      
        protected abstract T GetEntity(U entityContext, int id);

        protected abstract T GetEntity(U entityContext, Guid guid);
       




        public T Add(T entity)
        {
          
                using (U entityContext = new U())
                {
                    T addedEntity = AddEntity(entityContext, entity);
                    entityContext.SaveChanges();
                    return addedEntity;
                }
        
        }

        public void Remove(T entity)
        {
            using (U entityContext = new U())
            {
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            using (U entityContext = new U())
            {
                T entity = GetEntity(entityContext, id);
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        public void Remove(Guid guid)
        {
            using (U entityContext = new U())
            {
                T entity = GetEntity(entityContext, guid);
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
           
        }

        public T Update(T entity)
        {
            using (U entityContext = new U())
            {
                T existingEntity = UpdateEntity(entityContext, entity);

                SimpleMapper.PropertyMap(entity, existingEntity);

                entityContext.SaveChanges();
                return existingEntity;
            }
        }

        public IEnumerable<T> Get()
        {
          
            
            using (U entityContext = new U())
                return (GetEntities(entityContext)).ToArray();

        }

       

        public T Get(int id)
        {
            using (U entityContext = new U())
                return GetEntity(entityContext, id);
        }

        public T Get(Guid guid)
        {
            using (U entityContext = new U())
                return GetEntity(entityContext, guid);
        }

       
    }

    public abstract class CoreRepository<T, SRCH, U> : ICoreRepository<T, SRCH>
        where T : class, new()
        where SRCH : class, new()
        where U : DbContext, new()
    {

        protected abstract T AddEntity(U entityContext, T entity);
        protected abstract T UpdateEntity(U entityContext, T entity);
        protected abstract IEnumerable<T> GetEntities(U entityContext);
        protected abstract T GetEntity(U entityContext, int id);
        protected abstract T GetEntity(U entityContext, Guid guid);
        protected abstract IEnumerable<T> GetEntities(U entityContext,SRCH filter);
        protected abstract T GetFilteredEntity(U entityContext, SRCH filter);

        public T Add(T entity)
        {
            using (U entityContext = new U())
            {
                T addedEntity = AddEntity(entityContext, entity);
                entityContext.SaveChanges();
                return addedEntity;
            }
        }

        public T Get(int id)
        {
            using (U entityContext = new U())
                return GetEntity(entityContext, id);
        }

        public T Get(Guid guid)
        {
            using (U entityContext = new U())
                return GetEntity(entityContext, guid);
        }

        public void Remove(T entity)
        {
            using (U entityContext = new U())
            {
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }

        }

        public void Remove(int id)
        {
            using (U entityContext = new U())
            {
                T entity = GetEntity(entityContext, id);
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        public void Remove(Guid guid)
        {
            using (U entityContext = new U())
            {
                T entity = GetEntity(entityContext, guid);
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        public T Update(T entity)
        {
            using (U entityContext = new U())
            {
                T existingEntity = UpdateEntity(entityContext, entity);

                SimpleMapper.PropertyMap(entity, existingEntity);

                entityContext.SaveChanges();
                return existingEntity;
            }
        }


       
        public IEnumerable<T> Get()
        {
            using (U entityContext = new U())
                return GetEntities(entityContext).ToList();
        }

        public IEnumerable<T> Get(SRCH filter)
        {
            using (U entityContext = new U())
                return GetEntities(entityContext,filter).ToList();
        }

        public T GetFilteredEntity(SRCH filter)
        {
            using (U entityContext = new U())
                return GetFilteredEntity(entityContext,filter);
            
        }
    }


    public abstract class CoreRepository<T, VW, SRCH, U> : ICoreRepository<T, VW, SRCH>
        where T : class, new()
        where VW : class, new()
        where SRCH : class, new()
        where U : DbContext, new()
    {

        protected abstract T AddEntity(U entityContext, T entity);
        protected abstract T UpdateEntity(U entityContext, T entity);
        protected abstract IEnumerable<T> GetEntities(U entityContext);
        protected abstract T GetEntity(U entityContext, int id);
        protected abstract T GetEntity(U entityContext, Guid guid);
        protected abstract IEnumerable<VW> GetViewEntities(U entityContext, SRCH filter);
        protected abstract VW GetViewEntity(U entityContext, SRCH filter);
        protected abstract VW GetViewEntity(U entityContext, int id);
        protected abstract VW GetViewEntity(U entityContext, Guid guid);
        public T Add(T entity)
        {
            using (U entityContext = new U())
            {
                T addedEntity = AddEntity(entityContext, entity);
                entityContext.SaveChanges();
                return addedEntity;
            }
        }

        public T Get(int id)
        {
            using (U entityContext = new U())
                return GetEntity(entityContext, id);
        }

        public T Get(Guid guid)
        {
            using (U entityContext = new U())
                return GetEntity(entityContext, guid);
        }

        public void Remove(T entity)
        {
            using (U entityContext = new U())
            {
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }

        }

        public void Remove(int id)
        {
            using (U entityContext = new U())
            {
                T entity = GetEntity(entityContext, id);
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        public void Remove(Guid guid)
        {
            using (U entityContext = new U())
            {
                T entity = GetEntity(entityContext, guid);
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        public T Update(T entity)
        {
            using (U entityContext = new U())
            {
                T existingEntity = UpdateEntity(entityContext, entity);

                SimpleMapper.PropertyMap(entity, existingEntity);

                entityContext.SaveChanges();
                return existingEntity;
            }
        }


        public IEnumerable<VW> GetVwEntities(SRCH filter)
        {
            using (U entityContext = new U())
                return GetViewEntities(entityContext, filter).ToList();
        }

        public VW GetVwEntity(SRCH filter)
        {
            using (U entityContext = new U())
                return GetViewEntity(entityContext, filter);
        }

        public VW GetVwEntity(int id)
        {
            using (U entityContext = new U())
                return GetViewEntity(entityContext, id);
        }

        public VW GetVwEntity(Guid guid)
        {
            using (U entityContext = new U())
                return GetViewEntity(entityContext, guid);
        }

        public IEnumerable<T> Get()
        {
            using (U entityContext = new U())
                return GetEntities(entityContext).ToList();
        }
    }



}
