// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageBusAdapter.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The message bus adapter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Loader
{
    using System.ComponentModel.Composition;
    using ReactiveUI;

    [Export(typeof(IMessageBus))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class MessageBusAdapter : MessageBus
    {
    }
}