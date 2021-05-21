// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidatorFactoryTest.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The validator factory test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.UnitTests.Validation.Client
{
    //using UI.ProcessComponents.Validation;

    ///// <summary>
    ///// The validator factory test.
    ///// </summary>
    //[TestFixture]
    //public class ValidatorFactoryTest
    //{
    //    private IRegisterValidatorFactory _validatorFactory;

    //    [SetUp]
    //    public void SetUp()
    //    {
    //        _validatorFactory = new ValidatorFactory();
    //        _validatorFactory.Register<PlanReceiptOrder, PlanReceiptOrderValidator>();
    //    }

    //    [Test]
    //    public void GetAndSetValidatorInFactory()
    //    {
    //        var validator = _validatorFactory.GetValidator<PlanReceiptOrder>();
    //        Assert.That(validator, Is.Not.Null);
    //        Assert.That(validator, Is.InstanceOf<PlanReceiptOrderValidator>());
    //    }

    //    [Test]
    //    public void PlanReceiptOrderValidate()
    //    {
    //        var validateObject = new PlanReceiptOrder(10);
    //        IValidator validator = _validatorFactory.GetValidator(validateObject.GetType());
    //        ValidationResult validationResult = validator.Validate(validateObject);
    //    }
    //}


}
