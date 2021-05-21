// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateStateMessage.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the UpdateStateMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.Messages
{
    using UI.Entities;

    /// <summary>
    /// The update state message.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The type of entity.
    /// </typeparam>
    public class UpdateStateMessage<TEntity> : IMessage
        where TEntity : class, IUiEntity, IHasState
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateStateMessage{TEntity}"/> class.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public UpdateStateMessage(TEntity entity)
        {
            this.Entity = entity;
        }

        /// <summary>
        /// Gets the entity.
        /// </summary>
        public TEntity Entity { get; private set; }
    }
}