namespace Buisness.Workflows.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using NHibernate.Helper.Repository;

    public class SetStateEntityManagerFactory<T, TState>
    {
        private readonly IRepositoryFactory _repositoryFactory;
        public SetStateEntityManagerFactory(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }
        public ISetStateEntityManager<T, TState> Create()
        {
            var type = typeof(ISetStateEntityManager<T, TState>);
            IEnumerable<Type> setManager =
                Assembly.GetAssembly(typeof(ISetStateEntityManager<,>)).GetTypes().Where(type.IsAssignableFrom);

            if (!setManager.Any())
            {
                throw new Exception("Not found SetStateEntityManager.");
            }

            return (ISetStateEntityManager<T, TState>)Activator.CreateInstance(setManager.First(), _repositoryFactory);
        }
    }
}
