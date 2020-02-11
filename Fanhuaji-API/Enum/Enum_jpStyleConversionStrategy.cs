namespace Fanhuaji_API.Enum
{
    public enum Enum_jpConversionStrategy
    {
        /// <summary>
        /// 僅保護原文與日文相同的字
        /// </summary>
        protectOnlySameOrigin,
        /// <summary>
        /// 無（當成中文處理）
        /// </summary>
        none,
        /// <summary>
        /// 保護 
        /// </summary>
        protect,
        /// <summary>
        /// 修正
        /// </summary>
        fix
    }
}
