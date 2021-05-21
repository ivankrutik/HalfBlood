namespace UI.Infrastructure.ViewModels.PermissionMaterialDomain
{
    using Halfblood.Common;
    using JetBrains.Annotations;
    using ReactiveUI;
    using System.Collections.Generic;
    using UI.Entities.PermissionMaterialDomain;

    public interface IStatusPermissionMaterialUserViewModel : IRoutableViewModel,
                                                              IChangeStateViewModel<PermissionMaterialUser, PermissionMaterialUserState>
    {
        string Note { get; set; }
        void SetActionObjectCollection([NotNull] IList<PermissionMaterialUser> objects);
    }
}
