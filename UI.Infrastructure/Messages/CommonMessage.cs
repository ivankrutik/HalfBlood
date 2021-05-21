// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonMessage.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the IMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Infrastructure.Messages
{
    public interface IMessage
    {
    }

    public interface IUpdatedMessage<out TEntity> : IMessage<TEntity>
    {
    }

    public interface IAddedMessage<out TEntity> : IMessage<TEntity>
    {
    }

    public interface IMessage<out TEntity> : IMessage
    {
        TEntity Entity { get; }
    }

    public class AddedEntityMessage<TEntity> : IAddedMessage<TEntity>
    {
        public AddedEntityMessage(TEntity entity)
        {
            Entity = entity;
        }

        public TEntity Entity { get; private set; }
    }

    public class UpdatedEntityMessage<TEntity> : IUpdatedMessage<TEntity>
    {
        public UpdatedEntityMessage(TEntity entity)
        {
            Entity = entity;
        }

        public TEntity Entity { get; private set; }
    }
    public class SelectedEntityMessage<TEntity> : IMessage<TEntity>
    {
        public SelectedEntityMessage(TEntity entity)
        {
            Entity = entity;
        }

        public TEntity Entity { get; private set; }
    }
}