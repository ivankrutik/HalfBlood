namespace Halfblood.UnitTests.StateMachineTests
{
    using System;
    using Halfblood.Common;

    using ParusModel.Entities.PlanReceiptOrderDomain;
    using Rhino.Mocks;

    public enum OpenState { IsOpen, IsClosed }
    public enum ConfirmState { IsConfirm, IsNotConfirm }
    public enum AttachedState { IsAttached, IsNotAttached }

    public class Claim
    {
        public OpenState OpenState { get; set; }
    }
    public class Order
    {
        public ConfirmState ConfirmState { get; set; }
    }
    public class Certificate
    {
        public AttachedState AttachedState { get; set; }
    }
    public interface ITrigger
    {
        event Action SomeEvent;
    }

    public class StateMachineTest
    {
        public void test()
        {
            var trigger = MockRepository.GenerateStub<ITrigger>();
            var stateMachine = MockRepository.GenerateStub<IStateMachine<PlanCertificateState>>();

            stateMachine.Configure(PlanCertificateState.Close)
                .Trigger(trigger)
                .ToState(PlanCertificateState.Confirm)
                .Before(state => Console.WriteLine(state))
                .After(state => Console.WriteLine(state));
        }

        public void Test2()
        {
            var pc = new PlanCertificate();
            var pro = new PlanReceiptOrder();
            var pa = new PlanReceiptOrderPersonalAccount();

            //var openStateMachine = new StateMachine<PlanCertificateState, ITrigger>(
            //    () => pc.State,
            //    state => pc.State = state);

//            openStateMachine.Configure(PlanCertificateState.Close)
//                .Permit(
//                    pro.WhenAnyValue(x => x.State)
//                        .Where(state => state == PlanReceiptOrderState.Close)
//                        .Select(_ => Unit.Default),
//                    PlanCertificateState.Close)
//                .Permit(
//                    pro.WhenAnyValue(x => x.State)
//                        .Where(state => state == PlanReceiptOrderState.Confirm)
//                        .Select(_ => Unit.Default),
//                    PlanCertificateState.Confirm);
        }
    }

    public interface IStateMachine<TState>
    {
        IStateConfiguration<TState> Configure(PlanCertificateState close);
    }

    public interface IStateConfiguration<TState>
    {
        IStateConfiguration<TState> Trigger(ITrigger trigger);
        IStateConfiguration<TState> ToState(PlanCertificateState confirm);
        IStateConfiguration<TState> Before(Action<TState> action);
        IStateConfiguration<TState> After(Action<TState> action);
    }
}