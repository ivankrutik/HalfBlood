namespace Buisness.Components.StoredProcedure.Common
{
    using NHibernate.Helper;

    public class GetCertificateQualitySP : IStoredProcedure
    {
        public GetCertificateQualitySP(long rnWarehouse)
        {
            this.RnWarehouse = rnWarehouse;
        }

        [StoredParameter("Warehouse")]
        public long RnWarehouse { get; private set; }

        public string Name
        {
            get { return "GetCertificateQualitySP"; }
        }
    }
}
