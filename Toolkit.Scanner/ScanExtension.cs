using System.Linq;
using WIA;

namespace Toolkit.Scanner
{
    public static class ScanExtension
    {
        public static object GetProperty(this Properties searchBag, int propID)
        {
            var collection =
                searchBag.Cast<Property>().Where<Property>((Property prop) => prop.PropertyID == propID);
            return collection.Select<Property, object>((Property prop) => prop.get_Value()).FirstOrDefault<object>();
        }
        public static
            void SetProperty(this Properties propertis, int propID, object propValue)
        {

            var enumerator =
                propertis.Cast<Property>().Where<Property>((Property prop) => prop.PropertyID == propID).GetEnumerator();

            using (enumerator)
            {
                if (enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    current.set_Value(propValue);
                }
            }
        }
    }
}
