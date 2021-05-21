namespace Buisness.Workflows.Managers
{
    using Halfblood.Common;

    public interface ISetStateEntityManager<in T, in TState>
    {
        void SetState(T entity, TState newState, Sense sense = Sense.Falling);
    }
}
