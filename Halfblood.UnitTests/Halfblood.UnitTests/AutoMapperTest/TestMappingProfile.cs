// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestMappingProfile.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the EnumMappingTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests.AutoMapperTest
{
    using AutoMapper;

    using Buisness.Workflows;
    using Common;

    using NUnit.Framework;

    using UI.ProcessComponents.Mappings;

    /// <summary>
    /// The enum mapping test.
    /// </summary>
    public class TestMappingProfile
    {
        [Test]
        public void AutoMapperServiceProfiles()
        {
            new ConfigureWorkflow().LoadProfiles(null);
            Mapper.AssertConfigurationIsValid();
        }
        [Test]
        public void AutoMapperClientProfiles()
        {
            new ProfilesLauncher().LoadProfiles();
            Mapper.AssertConfigurationIsValid();
        }

        [TestCase(0, Result = ActInputControlState.New)]
        [TestCase(1, Result = ActInputControlState.Close)]
        public ActInputControlState AutoMapperActInputControlState(byte actInputControlState)
        {
            return Mapper.Map<byte, ActInputControlState>(actInputControlState);
        }
        [TestCase(0, Result = PlanReceiptOrderState.NotСonfirm)]
        [TestCase(1, Result = PlanReceiptOrderState.Confirm)]
        public PlanReceiptOrderState AutoMapperPlanReceiptOrderState(byte planReceiptOrderState)
        {
            return Mapper.Map<byte, PlanReceiptOrderState>(planReceiptOrderState);
        }
        [TestCase(0, Result = ActInputControlDestinationState.New)]
        [TestCase(1, Result = ActInputControlDestinationState.Close)]
        public ActInputControlDestinationState AutoMapperActInputControlDestinationState(byte actInputControlDestinationState)
        {
            return Mapper.Map<byte, ActInputControlDestinationState>(actInputControlDestinationState);
        }
    }
}
