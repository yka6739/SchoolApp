using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Core.Common.Contracts
{
    public interface IDataRepository
    {

    }
    public interface IDataRepository<T> : IDataRepository
        where T : class,  new()
    {
        T Add(T entity);

        void Remove(T entity);

        void Remove(int id);
        void Remove(Guid guid);

        T Update(T entity);

        IEnumerable<T> Get();
        T Get(int id);
        T Get(Guid guid);

    }

    public interface ICoreRepository
    {

    }
    public interface ICoreRepository<T, SRCH> : ICoreRepository
       where T : class, new()
       where SRCH : class, new()
    {
        T Add(T entity);
        void Remove(T entity);
        void Remove(int id);
        void Remove(Guid guid);
        T Update(T entity);
        IEnumerable<T> Get();
        T Get(int id);
        T Get(Guid guid);


        // View Related Functions
        IEnumerable<T> Get(SRCH filter);
        T GetFilteredEntity(SRCH filter);



    }

    public interface ICoreRepository<T, VW, SRCH> : ICoreRepository
        where T : class, new()
        where VW : class, new()
        where SRCH : class, new()
    {
        T Add(T entity);
        void Remove(T entity);
        void Remove(int id);
        void Remove(Guid guid);
        T Update(T entity);
        IEnumerable<T> Get();
        T Get(int id);
        T Get(Guid guid);


        // View Related Functions
        IEnumerable<VW> GetVwEntities(SRCH filter);
        VW GetVwEntity(SRCH filter);
        VW GetVwEntity(int id);
        VW GetVwEntity(Guid guid);




    }



}
