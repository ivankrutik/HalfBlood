using UI.Entities.CertificateQualityDomain.ManufacturersCertificateDomain;

namespace UI.Entities.DepartmentOrderDomain
{
    public class DepartmentOrderSpecification : EntityBase<DepartmentOrderSpecification>
    {
        public DepartmentOrderSpecification()
        {
        }
        public DepartmentOrderSpecification(long rn)
        {
            Rn = rn;
        }
        public decimal Quantity { get; set; }
        public  CertificateQuality CertificateQuality { get; set; }
        public string NameSectionOfSystem { get; protected set; }
        public DepartmentOrder DepartmentOrder { get; set; }
    }
}
