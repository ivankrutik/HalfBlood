// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.2.1
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.17929
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Halfblood.AcceptanceTests.Features.PlanCertificateDomain
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.2.1")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Добавление ПС (планового сертификата)")]
    public partial class ДобавлениеПСПлановогоСертификатаFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "InsertPlanCertificate.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("ru-RU"), "Добавление ПС (планового сертификата)", @"Хочу завести ПС


    CertificateQuality = CreateAndSave(session, CreateCertificateQuality),
       CountByDocument = 1,
       Note = ""sd"",
       StateDate = new DateTime(2013, 2, 2),
       PlanReceiptOrder = CreateAndSave(session, CreatePlanReceiptOrder),
       Price = 1,
       UserCreator = GetUserMaratoss(),
       CountFact = 3,
       State = PlanCertificateState.Close", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Добавление ПС")]
        [NUnit.Framework.CategoryAttribute("позитивный")]
        [NUnit.Framework.TestCaseAttribute("469", "287457664", "347089877", "777", "1.5.2013", "347089877", "888", "2.5.2013", "264833250", "примечание", null)]
        public virtual void ДобавлениеПС(string каталог, string склад, string тип, string номер, string дату, string тип_Для_Получения, string номер_Для_Получения, string дату_Для_Получения, string поставщик, string примечание, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "позитивный"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Добавление ПС", @__tags);
#line 16
this.ScenarioSetup(scenarioInfo);
#line 17
 testRunner.Given("Я хочу добавить ПС", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Допустим ");
#line 18
 testRunner.And(string.Format("я ввожу каталог {0}", каталог), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "И ");
#line 19
 testRunner.And(string.Format("ввожу склад {0}", склад), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "И ");
#line 20
 testRunner.And(string.Format("ввожу тип {0} документа основания", тип), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "И ");
#line 21
 testRunner.And(string.Format("ввожу № {0} документа основания", номер), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "И ");
#line 22
 testRunner.And(string.Format("ввожу дату {0} документа основания", дату), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "И ");
#line 23
 testRunner.And(string.Format("ввожу тип {0} документа основания для получения", тип_Для_Получения), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "И ");
#line 24
 testRunner.And(string.Format("ввожу № {0} документа основания для получения", номер_Для_Получения), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "И ");
#line 25
 testRunner.And(string.Format("ввожу дату {0} документа основания для получения", дату_Для_Получения), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "И ");
#line 26
 testRunner.And(string.Format("ввожу поставщика {0}", поставщик), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "И ");
#line 27
 testRunner.And(string.Format("ввожу примечание {0}", примечание), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "И ");
#line 28
 testRunner.When("я нажимаю кнопку Сохранить", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Когда ");
#line 29
 testRunner.Then("я вижу окно c сообщением - успешно добалено", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Тогда ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
