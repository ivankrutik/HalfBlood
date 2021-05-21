using System.Windows;
using Buisness.Entities.TestSheetDomain;

namespace UI.Components.TestSheetsDomain.DataTemplateSelector
{
    public class TestSheetResultsPresenterTemplateSelector : System.Windows.Controls.DataTemplateSelector
    {
        //       ^-- понятно же

        public DataTemplate SingleValueTemplate { get; set; }
        public DataTemplate TableValuesTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var dto = item as TestResultDto;
            return dto == null
                ? SingleValueTemplate
                : (dto.SampleResultSets.Count == 0 ? SingleValueTemplate : TableValuesTemplate);
        }
    }
}