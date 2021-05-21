using Buisness.Entities.PlanReceiptOrderDomain;
using NUnit.Framework;
using ParusModel.WorkOrderDomain.ActInputControlDomain;

namespace Halfblood.UnitTests.BuisnesWorkflow.Tests
{
    public class ActInputControlTechnicalStateTest : TestBase
    {
        [Test]
        public void Create()
        {
            OnTestOfCreate(service =>
                service.InsertActInputControlTechnicalState(
                    SampleEntityDto.CreateActInputControlTechnicalStateDto()));
        }
        [Test]
        public void Remove()
        {
            ActInputControlTechnicalStateDto act = SampleEntityDto.CreateActInputControlTechnicalStateDto();
            OnTestOfRemove<ActInputControlTechnicalStateDto, ActInputControlTechnicalState>(
                ref act,
                service => service.RemoveActInputControlTechnicalState(act));
        }
        [Test]
        public void Update()
        {
            ActInputControlTechnicalStateDto act = SampleEntityDto.CreateActInputControlTechnicalStateDto();
            OnTestOfUpdate<ActInputControlTechnicalStateDto, ActInputControlTechnicalState>(
                ref act,
                service => { act.Note = "new note!!!!"; service.UpdateActInputControlTechnicalState(act); },
                (dto, entity) => dto.Note == entity.Note);
        }
    }
}
