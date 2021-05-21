// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinkViewModel.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the LinkViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.ProcessComponents.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Reactive.Linq;
    using Buisness.Filters;
    using Halfblood.Common;
    using ParusModelLite.CommonDomain;
    using ReactiveUI;
    
    using ServiceContracts;
    using ServiceContracts.Facades;
    using UI.Infrastructure.Messages;
    using UI.Infrastructure.ViewModels.Common;

    [Export(typeof(ILinkViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class LinkViewModel : ReactiveObject, ILinkViewModel
    {
        #region Private Fields
        private readonly IMessageBus _messageBus;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private long _selectedEntity;
        private IList<LinkDto> _linksDtos;
        private bool _isFrozen=true;
        #endregion

        public IList<LinkDto> LinksDtos
        {
            get { return _linksDtos; }
            private set { this.RaiseAndSetIfChanged(ref _linksDtos, value); }
        
        }
        public DirectionFind Direction { get; set; }
        public bool IsFrozen
        {
            get { return _isFrozen; }
            set { this.RaiseAndSetIfChanged(ref _isFrozen, value); }
        }

        /// <summary>
        /// Gets the host screen.
        /// </summary>
        public IScreen HostScreen { get; private set; }

        /// <summary>
        /// Gets the url path segment.
        /// </summary>
        public string UrlPathSegment
        {
            get { return "/WorkflowView"; }
        }
        [ImportingConstructor]
        public LinkViewModel(IMessageBus messageBus, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _messageBus = messageBus;
            Initializer();
            _selectedEntity = 256263156;
            Load();
        }

        private void Initializer()
        {
            _messageBus.Listen<SelectedEntityMessage<long>>()
                   .ObserveOnUiSafeScheduler()
                   .Subscribe(x =>
                   {
                       _selectedEntity = x.Entity;
                       Load();
                   });
        }

        public void Load()
        {
            if (!IsFrozen) return;
            using (IUnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                var service = unitOfWork.Create<ICommonService>();

                LinksDtos =
                    service.GetLinkForWorkflow(new LinkFilter
                    {
                        Rn = _selectedEntity,
                        Direction = Direction
                    });

                unitOfWork.Commit();
            }
        }
    }
}
