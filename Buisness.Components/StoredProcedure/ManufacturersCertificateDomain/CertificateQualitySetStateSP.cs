namespace Buisness.Components.StoredProcedure.ManufacturersCertificateDomain
{
    using Halfblood.Common;
    using NHibernate.Helper;

    public class CertificateQualitySetStateSP : IStoredProcedure
    {
        public CertificateQualitySetStateSP(long rn, QualityCertificateState newState)
        {
            RN = rn;
           
            State = newState;
        }
        [StoredParameter("RN")]
        public long RN
        {
            get;
            private set;
        }
        [StoredParameter("newState")]
        public QualityCertificateState State
        {
            get;
            private set;
        }
       
        public string Name
        {
            get { return "CertificateQualitySetState"; }
        }
    }
}
