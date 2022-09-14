namespace EANExtractor
{
    class Program
    {
        static void Main(string[] args)
        {

            string EANdataStr = new EANdata().bigStr;

            Parser parser = new Parser(EANdataStr);
            string rawData = parser.getRawData();
            dynamic data = parser.stringToJson(rawData);

            if( data.GetType() is not string )
            {
                dynamic product = data.Product;
                string productId = product.ProductId;
                string title = product.Title;
                string brandTitle = product.BrandTitle;

                Console.WriteLine("Product ID (EAN): " + productId);
                Console.WriteLine("Title: " + title);
                Console.WriteLine("Brand title: " + brandTitle);
            } else {
                Console.WriteLine("There was no data.");
            }
        }
    }
}