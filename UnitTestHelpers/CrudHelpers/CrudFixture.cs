// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrudFixture.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the CrudFixture type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitTestHelpers.CrudHelpers
{
    using System;

    using Halfblood.Common;

    using NUnit.Framework;

    public abstract class CrudFixture<TEntity, TId> : AutoRollbackFixture
        where TEntity : class, IHasUid<TId>
    {
        public Boolean IsReadOnly { get; set; }

        [Test]
        public void can_select_entity()
        {
            this.Session.CreateCriteria<TEntity>().SetMaxResults(1).List();
        }

        [Test]
        public void can_create_entity()
        {
            if (IsReadOnly)
            {
                return;
            }

            var entity = this.BuildEntity();
            this.InsertEntity(entity);
            this.Session.Evict(entity);

            var reloadedEntity = this.Session.Get<TEntity>(entity.Rn);
            Assert.IsNotNull(reloadedEntity);
            this.AssertAreEqual(entity, reloadedEntity);
            this.AssertValidId(entity);
        }

        [Test]
        public void can_update_entity()
        {
            if (IsReadOnly)
            {
                return;
            }

            var entity = this.BuildEntity();
            this.InsertEntity(entity);
            this.ModifyEntity(entity);
            this.Session.Flush();
            this.Session.Evict(entity);

            var reloadedEntity = this.Session.Get<TEntity>(entity.Rn);
            this.AssertAreEqual(entity, reloadedEntity);
        }

        [Test]
        public void can_delete_entity()
        {
            if (IsReadOnly)
            {
                return;
            }

            var entity = this.BuildEntity();
            this.InsertEntity(entity);
            this.DeleteEntity(entity);
            Assert.IsNull(this.Session.Get<TEntity>(entity.Rn));
        }

        protected virtual void InsertEntity(TEntity entity)
        {
            this.Session.Save(entity);
            this.Session.Flush();
        }

        protected virtual void DeleteEntity(TEntity entity)
        {
            this.Session.Delete(entity);
            this.Session.Flush();
        }

        protected abstract TEntity BuildEntity();
        protected abstract void ModifyEntity(TEntity entity);
        protected abstract void AssertAreEqual(TEntity expectedEntity, TEntity actualEntity);
        protected abstract void AssertValidId(TEntity entity);
    }
}
