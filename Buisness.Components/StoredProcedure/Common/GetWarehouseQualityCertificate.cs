namespace Buisness.Components.StoredProcedure.Common
{
    using NHibernate.Helper;

    public class GetWarehouseQualityCertificate : IStoredProcedure
    {
        public GetWarehouseQualityCertificate(long rnCertificateQuality)
        {
            RnCertificateQuality = rnCertificateQuality;
        }

        [StoredParameter("CertificateQuality")]
        public long RnCertificateQuality { get; private set; }

        public string Name
        {
            get { return "GetWarehouseQualityCertificate"; }
        }
    }
}
