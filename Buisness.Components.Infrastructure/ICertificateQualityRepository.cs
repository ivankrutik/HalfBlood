using System.Collections.Generic;
using Buisness.Entities.PlanReceiptOrderDomain;
using ParusModel.WorkOrderDomain.ActInputControlDomain;

namespace Buisness.Components.Infrastructure
{
    public interface ICertificateQualityRepository
    {
        IEnumerable<CertificateQualityDto> CertificateQualityFilter(
            CertificateQualityDto filter, int skip, int take, out int total);
        CertificateQualityDto Add(CertificateQualityDto certificate);
    }
}