# Fanhuaji-API
An easy way to use Fanhuaji-API

## Use
由於要繁化姬，則需要同意一些作者提出的小規定，相關約定如下  
```
繁化姬的後端可能會留存您所提供的文本與使用者設定，以做為改進轉換正確率的用途。  
繁化姬並不保證所有轉換都是正確的，並且不為轉換錯誤而造成的損失負責。 若您的文本為正式的文件，您應該在轉換後親自校閱它。  
繁化姬會於字幕中，加入不妨礙實際觀看效果的內容以做為推廣用途。 在「免費」使用繁化姬的情況下，我方不允許您將這些內容去除。 （商業用途請見商業使用)  
如需商用必須付費給繁化姬  
  
繁化姬官方網站：https://zhconvert.org/
```
**如不同意此協議，請勿使用此API**

```C#
var Fanhuaji = new Fanhuaji(Agree: true, Terms_of_Service: Fanhuaji_API.Fanhuaji.Terms_of_Service);
await Fanhuaji.ConvertAsync("繁體中文轉簡體中文", Fanhuaji_API.Enum.Enum_Converter.Simplified, new Config() { });
```
