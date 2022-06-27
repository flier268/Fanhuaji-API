using Fanhuaji_API.Models;

namespace Fanhuaji_APITests.Models
{
    [TestFixture]
    public class ModuleTests
    {
        [Test]
        public void Name_should_be_defined()
        {
            // Arrange
            Assert.DoesNotThrow(() =>
            {
                foreach (var modules in Enum.GetValues<Enum_Modules>())
                {
                    Module module = new(modules, false);
                    _ = module.Name;
                }
            });
        }

        [Test]
        public void Type_should_be_defined()
        {
            // Arrange
            Assert.DoesNotThrow(() =>
            {
                foreach (var modules in Enum.GetValues<Enum_Modules>())
                {
                    Module module = new(modules, false);
                    _ = module.Type;
                }
            });
        }

        [Test]
        public void Description_should_be_defined()
        {
            // Arrange
            Assert.DoesNotThrow(() =>
            {
                foreach (var modules in Enum.GetValues<Enum_Modules>())
                {
                    Module module = new(modules, false);
                    _ = module.Description;
                }
            });
        }

        [Test]
        public void ModuleName_and_enable_should_be_equal_constructor_arg()
        {
            // Arrange
            foreach (var modules in Enum.GetValues<Enum_Modules>())
            {
                Assert.Multiple(() =>
                {
                    Module module = new(modules, false);
                    Assert.That(module.ModuleName, Is.EqualTo(modules));
                    Assert.That(module.Enable, Is.False);

                    module = new Module(modules, true);
                    Assert.That(module.ModuleName, Is.EqualTo(modules));
                    Assert.That(module.Enable, Is.True);
                });
            }
        }
    }
}