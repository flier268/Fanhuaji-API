using Fanhuaji_API.Enum;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Fanhuaji_API.Class
{
    public class Module: INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public Module(Enum_Modules Modules,bool? Enable)
        {
            this.ModuleName = Modules;
            this.Enable = Enable;
        }
        public Enum_Modules ModuleName { get; set; }
        private bool? _Enable;
        public bool? Enable { get => _Enable; set { _Enable = value;OnPropertyChanged(); } }

        [ColumnName(null, false), JsonIgnore]
        public string Type
        {
            get
            {
                switch (ModuleName)
                {
                    case Enum_Modules.Smooth:
                    case Enum_Modules.Unit:
                    case Enum_Modules.ProperNoun:
                    case Enum_Modules.GanToZuo:
                    case Enum_Modules.InternetSlang:
                    case Enum_Modules.EngNumFWToHW:
                    case Enum_Modules.Typo:
                    case Enum_Modules.Computer:
                    case Enum_Modules.TransliterationToTranslation:
                        return "其他";
                    case Enum_Modules.Repeat:
                    case Enum_Modules.RepeatAutoFix:
                        return "功能性";
                    case Enum_Modules.OnePiece:
                    case Enum_Modules.Naruto:
                    case Enum_Modules.HunterXHunter:
                    case Enum_Modules.Pocketmon:
                    case Enum_Modules.VioletEvergarden:
                    case Enum_Modules.Gundam:
                        return "動畫";
                    case Enum_Modules.EllipsisMark:
                    case Enum_Modules.QuotationMark:
                        return "標點符號";
                    case Enum_Modules.Mythbusters:
                        return "電視劇";
                    default:
                        return "錯誤";
                }
            }
        }

        [ColumnName(null, false), JsonIgnore]
        public string Name
        {
            get
            {
                switch (ModuleName)
                {
                    case Enum_Modules.Smooth: return "修飾句子";
                    case Enum_Modules.Unit: return "單位轉換";
                    case Enum_Modules.ProperNoun: return "專有名詞";
                    case Enum_Modules.GanToZuo: return "幹→做";
                    case Enum_Modules.InternetSlang: return "網路用語";
                    case Enum_Modules.EngNumFWToHW: return "英數字半形化";
                    case Enum_Modules.Typo: return "錯別字修正";
                    case Enum_Modules.Computer: return "電腦詞彙";
                    case Enum_Modules.TransliterationToTranslation: return "音譯轉意譯";
                    case Enum_Modules.Repeat: return "重複字修正";
                    case Enum_Modules.RepeatAutoFix: return "重複字通用修正";
                    case Enum_Modules.OnePiece: return "海賊王";
                    case Enum_Modules.Naruto: return "火影忍者";
                    case Enum_Modules.HunterXHunter: return "獵人";
                    case Enum_Modules.Pocketmon: return "精靈寶可夢";
                    case Enum_Modules.VioletEvergarden: return "紫羅蘭永恆花園";
                    case Enum_Modules.Gundam: return "鋼彈";
                    case Enum_Modules.EllipsisMark: return "刪節號（省略號）";
                    case Enum_Modules.QuotationMark: return "引號";
                    case Enum_Modules.Mythbusters: return "流言終結者	";
                    default:
                        return "錯誤";
                }
            }
        }

        [ColumnName(null, false), JsonIgnore]
        public string Description
        {
            get
            {
                switch (ModuleName)
                {
                    case Enum_Modules.Smooth: return "刪補文字/修改文法 以使句子更符合台灣的習慣";
                    case Enum_Modules.Unit: return "將（距離、重量）單位轉換為當地的習慣用詞";
                    case Enum_Modules.ProperNoun: return "較具有通用性的人名、地名、片名、遊戲名等等…";
                    case Enum_Modules.GanToZuo: return "將「幹」轉換為「做」，對於裏番動畫不會啟用";
                    case Enum_Modules.InternetSlang: return "例如：杯具→悲劇、趕腳→感覺";
                    case Enum_Modules.EngNumFWToHW: return "轉換全形的英數字為半形";
                    case Enum_Modules.Typo: return "修正常見的錯別字，例如：因該→應該";
                    case Enum_Modules.Computer: return "可以用在應用程式的語系檔";
                    case Enum_Modules.TransliterationToTranslation: return "例如：胖次→內褲、歐派→胸部";
                    case Enum_Modules.Repeat: return "功能類似這樣：「神...神~神─馬」→「什...什~什─麼」";
                    case Enum_Modules.RepeatAutoFix: return "功能類似這樣：「視…視頻」→「影…影片」";
                    case Enum_Modules.OnePiece: return "日本動畫";
                    case Enum_Modules.Naruto: return "日本動畫";
                    case Enum_Modules.HunterXHunter: return "日本動畫";
                    case Enum_Modules.Pocketmon: return "日本動畫";
                    case Enum_Modules.VioletEvergarden: return "日本動畫";
                    case Enum_Modules.Gundam: return "日本動畫";
                    case Enum_Modules.EllipsisMark: return "將中文裡的「...」轉換成「…」";
                    case Enum_Modules.QuotationMark: return "轉換 中國／非中國 間的引號";
                    case Enum_Modules.Mythbusters: return "Discovery 科普片";
                    default:
                        return "錯誤";
                }
            }
        }
    }
}
