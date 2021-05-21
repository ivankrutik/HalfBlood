using Buisness.Entities.PlanReceiptOrderDomain;
using NUnit.Framework;
using ParusModel.WorkOrderDomain.ActInputControlDomain;

namespace Halfblood.UnitTests.BuisnesWorkflow.Tests
{
    public class SolutionByNoteTest : TestBase
    {
        [Test]
        public void Create()
        {
            OnTestOfCreate(service =>
                service.InsertSolutionByNote(SampleEntityDto.CreateSolutionByNote()));
        }
        [Test]
        public void Remove()
        {
            SolutionByNoteDto solution = SampleEntityDto.CreateSolutionByNote();
            OnTestOfRemove<SolutionByNoteDto, SolutionByNote>(
                ref solution,
                service => service.RemoveSolutionByNote(solution));
        }
        [Test]
        public void Update()
        {
            SolutionByNoteDto solution = SampleEntityDto.CreateSolutionByNote();
            OnTestOfUpdate<SolutionByNoteDto, SolutionByNote>(
                ref solution,
                service => { solution.Note = "new note!!!!"; service.UpdateSolutionByNote(solution); },
                (dto, entity) => dto.Note == entity.Note);
        }
    }
}
