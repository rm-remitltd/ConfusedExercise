using ConfusedExercise.Actors;
using ConfusedExercise.SystemUnderTest;
using TechTalk.SpecFlow;

namespace ConfusedExercise.Specflow
{
    [Binding]
    internal class Hooks
    {
        private readonly FeatureContext _featureContext;

        public Hooks(FeatureContext featureContext) => _featureContext = featureContext;
        
        [BeforeScenario]
        public void BeforeScenario()
        {
            if (_featureContext.FeatureContainer.IsRegistered<BrowserActor>()) return;

            _featureContext.FeatureContainer.RegisterInstanceAs(new BrowserActor(new TestConfiguration()), dispose: true);
        }
    }
}
