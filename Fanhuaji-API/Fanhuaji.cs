using Fanhuaji_API.Class;
using Fanhuaji_API.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fanhuaji_API
{
    /// <summary>
    /// 繁化姬
    /// </summary>
    public class Fanhuaji
    {
        public Fanhuaji(bool Agree, string Terms_of_Service)
        {
            if (Fanhuaji.Terms_of_Service != Terms_of_Service || !Agree)
                throw new Exception("You should agree to the Terms of Service.");
        }
        public static bool CheckConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://api.zhconvert.org/"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<Callback> ConvertAsync(string Text, Enum_Converter Converter, Config Config)
        {
            if (Text == null || Config == null)
                throw new Exception("Text or Config should not be null");
            Dictionary<string, string> content = new Dictionary<string, string>() { { "text", Text }, { "converter", Converter.ToString() } };
            foreach (var property in Config.GetType().GetProperties())
            {
                if (property.GetValue(Config) == null || !property.GetVisible())
                    continue;
                if (property.PropertyType == typeof(string))
                {
                    content.Add(property.GetColumnName(), (string)property.GetValue(Config));
                }
                else if (property.PropertyType == typeof(int))
                {
                    content.Add(property.GetColumnName(), property.GetValue(Config).ToString());
                }
                else if (property.PropertyType == typeof(bool))
                {
                    content.Add(property.GetColumnName(), property.GetValue(Config).ToString());
                }
                else if (property.PropertyType.IsEnum)
                {
                    content.Add(property.GetColumnName(), property.GetValue(Config).ToString());
                }
                else if (property.PropertyType == typeof(List<Module>))
                {
                    var Modules = property.GetValue(Config) as List<Module>;
                    string moudle = string.Join(",", Modules.Where(x => x.Enable != null).Select(x => $"\"{x.ModuleName}\":\"{(x.Enable == true ? 1 : 0)}\""));
                    content.Add(property.GetColumnName(), $"{{\"*\":\"-1\"{(string.IsNullOrEmpty(moudle) ? "" : ",")}{moudle}}}");
                }
                else if (property.PropertyType == typeof(List<KeyValue>))
                {
                    var dic = property.GetValue(Config) as List<KeyValue>;
                    content.Add(property.GetColumnName(), string.Join("\n", dic.Select(x => $"{x.Key}={x.Value}")));
                }
                else
                {
                    throw new Exception("Something wrong.");
                }
            }
            
            return Callback.FromJson(await PostAsync("https://api.zhconvert.org/convert", new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json")));
        }
        private static async Task<string> PostAsync(string url, HttpContent formUrlEncodedContent)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://api.zhconvert.org");                    
                    var result = await client.PostAsync(url, formUrlEncodedContent);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    return resultContent;
                }
            }
            catch (Exception e)
            {
                Debug.Print("Post Error:" + e.Message);
                throw new FanhuajiException("無法連線至繁化姬，請確認連線狀態");
            }
        }
        public const string Terms_of_Service = "繁化姬的後端可能會留存您所提供的文本與使用者設定，以做為改進轉換正確率的用途。\r\n" +
            "繁化姬並不保證所有轉換都是正確的，並且不為轉換錯誤而造成的損失負責。 若您的文本為正式的文件，您應該在轉換後親自校閱它。\r\n" +
            "繁化姬會於字幕中，加入不妨礙實際觀看效果的內容以做為推廣用途。 在「免費」使用繁化姬的情況下，我方不允許您將這些內容去除。 （商業用途請見商業使用）\r\n" +
            "如需商用必須付費給繁化姬" +
            "\r\n" +
            "繁化姬官方網站：https://zhconvert.org/";
        public class FanhuajiException : Exception
        {
            public FanhuajiException(string message) : base(message)
            {
            }
        }
    }
}
