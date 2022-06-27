namespace Fanhuaji_APITests
{
    [TestFixture]
    public class FanhuajiTests
    {
        [Test]
        public void Constrocotr_throw_exception_while_user_not_accept_EULA()
        {
            Assert.Multiple(() =>
            {
                Assert.Throws<Exception>(() => { new Fanhuaji(false, Fanhuaji.Terms_of_Service); });
                Assert.Throws<Exception>(() => { new Fanhuaji(false, null); });
                Assert.Throws<Exception>(() => { new Fanhuaji(true, null); });
                Assert.DoesNotThrow(() => { new Fanhuaji(true, Fanhuaji.Terms_of_Service); });
            });
        }

        [Test]
        public void CheckConnection_should_pass_while_api_is_useable()
        {
            // Act
            Assert.That(Fanhuaji.CheckConnection(), Is.True);
        }

        [Test]
        public void ConvertAsync_should_return_corresponding_value()
        {
            // Arrange
            Fanhuaji? fanhuaji = new(true, Fanhuaji.Terms_of_Service);
            Assert.Multiple(async () =>
            {
                Assert.DoesNotThrowAsync(async () => await fanhuaji.ConvertAsync("繁體轉簡體", Enum_Converter.Simplified));
                // Act
                Assert.That((await fanhuaji.ConvertAsync("简体转繁体", Enum_Converter.Traditional)).Data.Text, Is.EqualTo("簡體轉繁體"));
                Assert.That((await fanhuaji.ConvertAsync("繁體轉簡體", Enum_Converter.Simplified)).Data.Text, Is.EqualTo("繁体转简体"));
            });
        }
    }
}