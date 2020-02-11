using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace Fanhuaji_API.Class
{
    public partial class Callback
    {
        /// <summary>
        /// 錯誤碼，非 0 時表示有錯誤發生以致任務無法進行。錯誤訊息請查看 msg 欄位。
        /// </summary>
        [JsonProperty("code")]
        public long Code { get; set; }

        /// <summary>
        /// 任務完成後的結果將存放於此，內容視 API 端點而定。
        /// </summary>
        [JsonProperty("data")]
        public Data Data { get; set; }

        /// <summary>
        /// 警告訊息或是錯誤訊息。
        /// </summary>
        [JsonProperty("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// 繁化姬的訊息
        /// </summary>
        [JsonProperty("revisions")]
        public Revisions Revisions { get; set; }

        /// <summary>
        /// 此次任務的耗時（單位為秒）。
        /// </summary>
        [JsonProperty("execTime")]
        public double ExecTime { get; set; }
    }

    public partial class Data
    {
        /// <summary>
        /// 此次轉換所使用的轉換器。
        /// </summary>
        [JsonProperty("converter")]
        public string Converter { get; set; }

        /// <summary>
        /// 經過轉換後的文本。
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// 轉換前後的文本差異比較。若轉換時沒有啟用差異比較，則傳回 null 。
        /// </summary>
        [JsonProperty("diff")]
        public object Diff { get; set; }

        /// <summary>
        /// 輸入的文本被繁化姬判定為何種格式。
        /// </summary>
        [JsonProperty("textFormat")]
        public string TextFormat { get; set; }

        /// <summary>
        /// 此次轉換使用了哪些模組。
        /// </summary>
        [JsonProperty("usedModules")]
        public string[] UsedModules { get; set; }

        /// <summary>
        /// 此次轉換將哪些樣式視為日文樣式。
        /// </summary>
        [JsonProperty("jpTextStyles")]
        public object[] JpTextStyles { get; set; }
    }

    public partial class Revisions
    {
        /// <summary>
        /// 繁化姬當下的版本號。
        /// </summary>
        [JsonProperty("build")]
        public string Build { get; set; }

        /// <summary>
        /// 繁化姬當下的版本的更新訊息。
        /// </summary>
        [JsonProperty("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// 繁化姬當下的版本的 UNIX 時間戳（單位為秒）。
        /// </summary>
        [JsonProperty("time")]
        public long Time { get; set; }
    }

    public partial class Callback
    {
        public static Callback FromJson(string json) => JsonConvert.DeserializeObject<Callback>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Callback self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
