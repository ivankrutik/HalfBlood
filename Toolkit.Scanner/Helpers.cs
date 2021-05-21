namespace Toolkit.Scanner
{
    using System;
    using WIA;

    static class Helpers
    {

        public static Item SetParams(this Item _scanner, double dpi, double brid)
        {
            Object object1;
            Object object2;

            object1 = (Object)"6146";
            object2 = (Object)4;
            _scanner.Properties.get_Item(ref object1).set_Value(ref object2);
            object1 = (Object)"6147";
            object2 = (Object)dpi;
            _scanner.Properties.get_Item(ref object1).set_Value(ref object2);
            object1 = (Object)"6154";
            object2 = (Object)brid;
            _scanner.Properties.get_Item(ref object1).set_Value(ref object2);
            object1 = (Object)"6148";
            object2 = (Object)dpi;
            _scanner.Properties.get_Item(ref object1).set_Value(ref object2);
            object1 = (Object)"6149";
            object2 = (Object)0;
            _scanner.Properties.get_Item(ref object1).set_Value(ref object2);
            object1 = (Object)"6150";
            object2 = (Object)0;
            _scanner.Properties.get_Item(ref object1).set_Value(ref object2);
            object1 = (Object)"6151";
            object2 = (Object)(8.5 * dpi);
            _scanner.Properties.get_Item(ref object1).set_Value(ref object2);
            object1 = (Object)"6152";
            object2 = (Object)(11.5 * dpi);
            //_scanner.Properties.get_Item(ref object1).set_Value(ref object2);
            object1 = (Object)"3088";
            object2 = (Object)(5);
            //_scanner.Properties.get_Item(ref object1).set_Value(ref object2);
            return _scanner;
        }
    }
}


