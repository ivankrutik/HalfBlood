// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWorkFactory.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IUnitOfWorkFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NhConnection
{
    using System.Data;

    /// <summary>
    /// The UnitOfWorkFactory interface.
    /// </summary>
    public interface IUnitOfWorkFactory
    {
        /// <summary>
        /// Создает uow, если у uow не будет вызван метод <see cref="IUnitOfWork.Commit" />, то автоматически будет выполнен rollback
        /// </summary>
        /// <param name="isolationLevel">
        /// The isolation level.
        /// </param>
        /// <returns>
        /// The <see cref="IUnitOfWork"/>.
        /// </returns>
        IUnitOfWork Create(IsolationLevel isolationLevel);

        /// <summary>
        /// Создает uow, если у uow не будет вызван метод <see cref="IUnitOfWork.Commit" />, то автоматически будет выполнен rollback
        /// </summary>
        /// <returns>
        /// The <see cref="IUnitOfWork"/>.
        /// </returns>
        IUnitOfWork Create();
    }
}