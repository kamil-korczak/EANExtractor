using HtmlAgilityPack;
using System.Web;
using Newtonsoft.Json;

namespace EANExtractor {

    public class Parser {

        private HtmlDocument html;


        public Parser(string html){
            this.html = loadHtml(html);
        }

        public HtmlDocument loadHtml(string html){
            HtmlDocument html_code = new HtmlDocument();
            html_code.LoadHtml(html);
            return html_code;
        }

        public string getRawData()
        {
            return html.DocumentNode.SelectSingleNode("//rfp-mctb-product-buynow").GetAttributeValue(":datas", "");
        }

        public dynamic stringToJson(string data){
            string decoded_data =  HttpUtility.HtmlDecode(data);
            dynamic? json_data = JsonConvert.DeserializeObject<dynamic>(decoded_data);

            if (json_data is null)
            {
                return "";
            }
            else {
                return json_data;
            }
        }
    }
}