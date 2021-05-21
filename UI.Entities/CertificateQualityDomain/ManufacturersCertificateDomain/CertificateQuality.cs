// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CertificateQuality.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The certificate quality.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;

    using ReactiveUI;

    using UI.Entities.AttachedDocumentDomain;
    using UI.Entities.CommonDomain;
    using UI.Entities.PlanReceiptOrderDomain;
    using Halfblood.Common;

    public class CertificateQuality : EntityBase<CertificateQuality>, IHasDocument
    {
        #region private fields
        private ReactiveList<MechanicIndicatorValue> _mechanicIndicatorValues;
        private ReactiveList<Destination> _destinations;
        private ReactiveList<Pass> _passes;
        private ReactiveList<ChemicalIndicatorValue> _chemicalIndicatorValues;
        private ReactiveList<CertificateQualityAttachedDocument> _documents;
        private IDisposable _chemicDisposable;
        private IDisposable _mechanicDisposable;
        private IDisposable _passDisposable;
        private IDisposable _destinationDisposable;
        private IDisposable _attachedDocumentsDisposable;
        #endregion

        public CertificateQuality(long rn)
            : this()
        {
            this.Rn = rn;
        }

        public CertificateQuality()
        {
            _chemicDisposable = Disposable.Empty;
            _mechanicDisposable = Disposable.Empty;
            _passDisposable = Disposable.Empty;
            _destinationDisposable = Disposable.Empty;
            _attachedDocumentsDisposable = Disposable.Empty;

            this.Passes = new ReactiveList<Pass>();
            this.ChemicalIndicatorValues = new ReactiveList<ChemicalIndicatorValue>();
            this.MechanicIndicatorValues = new ReactiveList<MechanicIndicatorValue>();
            this.Destinations = new ReactiveList<Destination>();
            this.Documents = new ReactiveList<CertificateQualityAttachedDocument>();
        }

        public QualityCertificateState State { get; set; }
        public DateTime StateDate { get; set; }
        public PlanCertificate PlanCertificate { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Marka { get; set; }
        public string Cast { get; set; }
        public string FullRepresentation { get; set; }
        public string GostCast { get; set; }
        public string GostMix { get; set; }
        public DateTime? MakingDate { get; set; }
        public decimal? Numb { get; set; }
        public string Pref { get; set; }
        public string NumberOfCertificate { get; set; }
        public string Note { get; set; }
        public string Mix { get; set; }
        public DateTime? StorageDate { get; set; }
        public string Sizes { get; set; }
        public User CreatorFactory { get; set; }
        public User UserCreator { get; set; }
        public DictionaryPass Pass { get; set; }
        public ReactiveList<ChemicalIndicatorValue> ChemicalIndicatorValues
        {
            get { return this._chemicalIndicatorValues; }
            set
            {
                _chemicDisposable.Dispose();

                if (value != null)
                {
                    _chemicDisposable =
                        value.Changed.Where((args, index) => args.NewItems != null)
                            .Subscribe(
                                args =>
                                args.NewItems.Cast<ChemicalIndicatorValue>().DoForEach(x => x.CertificateQuality = this));
                }

                this._chemicalIndicatorValues = value;
                this.OnPropertyChanged();
            }
        }
        public ReactiveList<MechanicIndicatorValue> MechanicIndicatorValues
        {
            get { return this._mechanicIndicatorValues; }
            set
            {
                _mechanicDisposable.Dispose();

                if (value != null)
                {
                    _mechanicDisposable =
                        value.Changed.Where((args, index) => args.NewItems != null)
                            .Subscribe(
                                args =>
                                args.NewItems.Cast<MechanicIndicatorValue>().DoForEach(x => x.CertificateQuality = this));
                }

                this._mechanicIndicatorValues = value;
                this.OnPropertyChanged();
            }
        }
        public ReactiveList<Destination> Destinations
        {
            get { return this._destinations; }
            set
            {
                _destinationDisposable.Dispose();

                if (value != null)
                {
                    _destinationDisposable =
                        value.Changed.Where((args, index) => args.NewItems != null)
                            .Subscribe(
                                args => args.NewItems.Cast<Destination>().DoForEach(x => x.CertificateQuality = this));
                }

                this._destinations = value;
                this.OnPropertyChanged();
            }
        }
        public ReactiveList<Pass> Passes
        {
            get { return this._passes; }
            set
            {
                _passDisposable.Dispose();

                if (value != null)
                {
                    _passDisposable =
                        value.Changed.Where((args, index) => args.NewItems != null)
                            .Subscribe(args => args.NewItems.Cast<Pass>().DoForEach(x => x.CertificateQuality = this));
                }

                this._passes = value;
                this.OnPropertyChanged();
            }
        }
        public ReactiveList<CertificateQualityAttachedDocument> Documents
        {
            get { return this._documents; }
            set
            {
                _attachedDocumentsDisposable.Dispose();

                if (value != null)
                {
                    _attachedDocumentsDisposable =
                        value.Changed.Where((args, index) => args.NewItems != null)
                            .Subscribe(args => args.NewItems.Cast<CertificateQualityAttachedDocument>().DoForEach(x => x.Parent = this));
                }

                this._documents = value;
                this.OnPropertyChanged();
            }
        }
        IList<CertificateQualityAttachedDocument> IHasDocument.Documents
        {
            get { return this.Documents; }
        }
    }
}