// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanCertificateRepository.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the PlanCertificateRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Buisness.Components
{
    using NHibernate;
    using NHibernate.Helper;

    using ParusModel.Entities.PlanReceiptOrderDomain;

    /// <summary>
    /// The plan certificate repository.
    /// </summary>
    [RepositoryForEntity(typeof(PlanCertificate))]
    public class PlanCertificateRepository : NhRepository<PlanCertificate>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlanCertificateRepository"/> class.
        /// </summary>
        /// <param name="session">
        /// The session.
        /// </param>
        public PlanCertificateRepository(ISession session)
            : base(session)
        {
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public override void Update(PlanCertificate entity)
        {
            var pc = Session.Merge(entity);
            var cq = Session.Merge(entity.CertificateQuality);

            Session.Update(pc);
            Session.Update(cq);
        }

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="long"/>.
        /// </returns>
        public override object Insert(PlanCertificate entity)
        {
            if (entity.CertificateQuality.Rn == 0)
            {
                Session.Save(entity.CertificateQuality);
            }

            return base.Insert(entity);
        }
    }
}
