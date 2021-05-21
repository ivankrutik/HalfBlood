using Buisness.Components.StoredProcedure.Common;
using Halfblood.Common;
using NHibernate.Helper.Filter.Specification;

namespace Halfblood.UnitTests.__
{
    using NhConnection;

    using NHibernate;
    using NUnit.Framework;

    public class MyClass
    {
        public long RN { get; set; }
    }
    public class Link : TestBase
    {
        [Test]
        public void Test2()
        {
            var connection = new NhConnection("hibernate.cfg.xml");
            connection.Connecting();
            ISession session = connection.GetSessionFactory().OpenSession();

            //IQuery Q = session.GetNamedQuery("Get_Links")
            //    //.SetResultTransformer(new ToListResultTransformer());
            //    //session.CreateSQLQuery("").ad
            //   .SetParameter("RN", 253655604)
            //    .SetParameter("Direction", DirectionFind.Forward);

            // IQuery Q = session.CreateSQLQuery("   select PKG_UDO_UTIL.F_GetLinks()1 as ret from dual ").AddEntity(typeof(LinkDto));
            //typeof(LinkDto);
            var sp = new GetLinks(253655604, DirectionFind.Backward);
            var Q = session.ExecuteSp(sp);
            var result = Q.List();


            //var query = MockRepository.GenerateMock<IQueryOver<LinkDto, LinkDto>>();
            //query.Stub(x => x.List<LinkDto>()).Return();


        }
    }
}
