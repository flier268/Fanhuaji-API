using Fanhuaji_API.Enum;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Fanhuaji_API.Models
{
    public class Config
    {
        /// <summary>
        /// 由那些不希望被繁化姬處理的 "樣式" 以逗號分隔所組成的字串。通常用於保護特效字幕不被轉換，例如字幕組的特效字幕若是以 OPJP 與 OPCN 作為樣式名。可以設定 "OPJP,OPCN" 來作保護。
        /// </summary>
        [JsonPropertyName("ignoreTextStyles")]
        public string IgnoreTextStyles { get; set; }

        /// <summary>
        /// 告訴繁化姬哪些樣式要當作日文處理（預設為伺服器端自動猜測）。若要自行設定，則必須另外再加入 *noAutoJpTextStyles 這個樣式。所有樣式以逗號分隔組成字串，例如： "OPJP,EDJP,*noAutoJpTextStyles" 表示不讓伺服器自動猜測，並指定 OPJP 與 EDJP 為日文樣式。
        /// </summary>
        [JsonPropertyName("jpTextStyles")]
        public string JpTextStyles { get; set; }

        /// <summary>
        /// 對於日文樣式該如何處理
        /// </summary>
        [JsonPropertyName("jpStyleConversionStrategy")]
        public Enum_jpConversionStrategy JpStyleConversionStrategy { get; set; }

        /// <summary>
        /// 對於繁化姬自己發現的日文區域該如何處理
        /// </summary>
        [JsonPropertyName("jpTextConversionStrategy")]
        public Enum_jpConversionStrategy JpTextConversionStrategy { get; set; }

        /// <summary>
        /// 強制設定模組啟用／停用
        /// </summary>
        [JsonPropertyName("modules")]
        public List<Module> Modules { get; set; } = new List<Module>();

        /// <summary>
        /// 轉換後再進行的額外取代
        /// </summary>
        [JsonPropertyName("userPostReplace")]
        public List<KeyValue> UserPostReplace { get; set; } = new List<KeyValue>();

        /// <summary>
        /// 轉換前先進行的額外取代
        /// </summary>
        [JsonPropertyName("userPreReplace")]
        public List<KeyValue> UserPreReplace { get; set; } = new List<KeyValue>();

        /// <summary>
        /// 保護字詞不被繁化姬修改
        /// </summary>
        [JsonPropertyName("userProtectReplace")]
        public List<KeyValue> UserProtectReplace { get; set; } = new List<KeyValue>();

        /// <summary>
        /// 是否使用字元級別的差異比較（否則為行級別），這將會使回應時間變長。
        /// </summary>
        [JsonPropertyName("diffCharLevel")]
        public bool DiffCharLevel { get; set; }

        /// <summary>
        /// 所輸出的結果要包含多少行上下文。可以是 0~4 之間的整數。
        /// </summary>
        [JsonPropertyName("diffContextLines")]
        public int DiffContextLines { get; set; } = 1;

        /// <summary>
        /// 是否要啟用差異比較。
        /// </summary>
        [JsonPropertyName("diffEnable")]
        public bool DiffEnable { get; set; }

        /// <summary>
        /// 是否要忽略英文大小寫的差異。
        /// </summary>
        [JsonPropertyName("diffIgnoreCase")]
        public bool DiffIgnoreCase { get; set; }

        /// <summary>
        /// 是否要忽略空格的差異。
        /// </summary>
        [JsonPropertyName("diffIgnoreWhiteSpaces")]
        public bool DiffIgnoreWhiteSpaces { get; set; }

        /// <summary>
        /// 所要使用的輸出模板
        /// </summary>
        [JsonPropertyName("diffTemplate")]
        public Enum_diffTemplate DiffTemplate { get; set; }

        /// <summary>
        /// 根據所偵測到的文本格式做出對應的文本清理。例如 ASS 字幕 的編輯器訊息、空白的對話等等，將會被移除
        /// </summary>
        [JsonPropertyName("cleanUpText")]
        public bool CleanUpText { get; set; }

        /// <summary>
        /// 確保輸出的文本結尾處有一個且只有一個換行符。
        /// </summary>
        [JsonPropertyName("ensureNewlineAtEof")]
        public bool EnsureNewlineAtEof { get; set; }

        /// <summary>
        /// 轉換每行開頭的 Tab 為數個空格。此值可以是 -1~8 之間的整數。 -1 表示不轉換； 0 表示移除開頭 Tab 。 1~8 表示轉換為數個空白。
        /// </summary>
        [JsonPropertyName("translateTabsToSpaces")]
        public int TranslateTabsToSpaces { get; set; } = -1;

        /// <summary>
        /// 移除每行結尾的多餘空格。
        /// </summary>
        [JsonPropertyName("trimTrailingWhiteSpaces")]
        public bool TrimTrailingWhiteSpaces { get; set; }

        /// <summary>
        /// 將區分說話人用的連字號統一為半形減號。
        /// </summary>
        [JsonPropertyName("unifyLeadingHyphen")]
        public bool UnifyLeadingHyphen { get; set; }
    }
}