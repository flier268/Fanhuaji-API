namespace Fanhuaji_API.Enum
{
    public enum Enum_Modules
    {
        /// <summary>
        /// 修飾句子---刪補文字/修改文法 以使句子更符合台灣的習慣
        /// </summary>
        Smooth,
        /// <summary>
        /// 刪節號（省略號）---將中文裡的「...」轉換成「…」 （必須手動啟用）
        /// </summary>
        EllipsisMark,
        /// <summary>
        /// 單位轉換---將（距離、重量）單位轉換為當地的習慣用詞
        /// </summary>
        Unit,
        /// <summary>
        /// 專有名詞---較具有通用性的人名、地名、片名、遊戲名等等…
        /// </summary>
        ProperNoun,
        /// <summary>
        /// 幹→做---將「幹」轉換為「做」，對於裏番動畫不會啟用。
        /// </summary>
        GanToZuo,
        /// <summary>
        /// 引號---轉換 中國／非中國 間的引號 （必須手動啟用）
        /// </summary>
        QuotationMark,
        /// <summary>
        /// 流言終結者---Discovery 科普片 （必須手動啟用）
        /// </summary>
        Mythbusters,
        /// <summary>
        /// 海賊王---日本動畫 （必須手動啟用）
        /// </summary>
        OnePiece,
        /// <summary>
        /// 火影忍者---日本動畫 （必須手動啟用）
        /// </summary>
        Naruto,
        /// <summary>
        /// 獵人---日本動畫 （必須手動啟用）
        /// </summary>
        HunterXHunter,
        /// <summary>
        /// 精靈寶可夢---日本動畫 （必須手動啟用）
        /// </summary>
        Pocketmon,
        /// <summary>
        /// 紫羅蘭永恆花園---日本動畫（由 ssnake 提供） （必須手動啟用）
        /// </summary>
        VioletEvergarden,
        /// <summary>
        /// 網路用語---例如：杯具→悲劇、趕腳→感覺
        /// </summary>
        InternetSlang,
        /// <summary>
        /// 英數字半形化---轉換全形的英數字為半形 （必須手動啟用）
        /// </summary>
        EngNumFWToHW,
        /// <summary>
        /// 重複字修正---功能類似這樣：「神...神~神─馬」→「什...什~什─麼」，使用字典式的修正。
        /// </summary>
        Repeat,
        /// <summary>
        /// 重複字通用修正---功能類似這樣：「視…視頻」→「影…影片」，使用非字典式的修正。
        /// </summary>
        RepeatAutoFix,
        /// <summary>
        /// 鋼彈---日本動畫 （必須手動啟用）
        /// </summary>
        Gundam,
        /// <summary>
        /// 錯別字修正---修正常見的錯別字，例如：因該→應該
        /// </summary>
        Typo,
        /// <summary>
        /// 電腦詞彙---可以用在應用程式的語系檔 （必須手動啟用）
        /// </summary>
        Computer,
        /// <summary>
        /// 音譯轉意譯---例如：胖次→內褲、歐派→胸部 （必須手動啟用）
        /// </summary>
        TransliterationToTranslation
    }
}
