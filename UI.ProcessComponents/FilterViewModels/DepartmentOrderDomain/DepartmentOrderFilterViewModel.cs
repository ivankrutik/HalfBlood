// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DepartmentOrderFilterViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the DepartmentOrderFilterViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.FilterViewModels.DepartmentOrderDomain
{
    using System.ComponentModel.Composition;

    using Buisness.Filters;

    using ParusModelLite.DepartmentOrderDomain;

    using ReactiveUI;

    using ServiceContracts;

    using UI.Infrastructure.ViewModels.Filters;

    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IDepartmentOrderFilterViewModel))]
    public class DepartmentOrderFilterViewModel : GenericFilterViewModel<DepartmentOrderFilter, DepartmentOrderLiteDto>,
                                                  IDepartmentOrderFilterViewModel
    {
        [ImportingConstructor]
        public DepartmentOrderFilterViewModel(IScreen screen, IUnitOfWorkFactory unitOfWorkFactory)
            : base(unitOfWorkFactory)
        {
            HostScreen = screen;
            Filter = DepartmentOrderFilter.Default;
        }

        public string UrlPathSegment
        {
            get { return "DepartmentOrderFilterViewModel"; }
        }
        public IScreen HostScreen { get; private set; }
    }
}