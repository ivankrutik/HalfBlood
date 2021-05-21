namespace UI.Infrastructure.Messages
{
    public class EnteredBarcodeMessage : IMessage
    {
        public EnteredBarcodeMessage(string barcode)
        {
            Barcode = barcode;
        }

        public string Barcode { get; private set; }
    }
}
