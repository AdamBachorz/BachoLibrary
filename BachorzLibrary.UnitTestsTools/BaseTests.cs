using BachorzLibrary.DAL.DotNetSix.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BachorzLibrary.UnitTestsTools
{
    public abstract class BaseTests
    {
        protected IFixture _fixture;
        protected IEFCCustomConfig _customConfig;

        public void Setup(string configFilePath)
        {
            _fixture = new Fixture().Customize(new AutoNSubstituteCustomization()
            {
                ConfigureMembers = true
            });
            _customConfig = JsonConvert.DeserializeObject<EFCCustomConfig>(File.ReadAllText(configFilePath));
        }
    }
}