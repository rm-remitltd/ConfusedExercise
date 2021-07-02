using TechTalk.SpecFlow;

namespace ConfusedExercise.Specflow
{
    internal abstract class StepsBase : Steps
    {
        internal void Save<TObj>(TObj obj) => ScenarioContext.Add(typeof(TObj).FullName, obj);

        internal TObj Retrieve<TObj>() => ScenarioContext.Get<TObj>(typeof(TObj).FullName);
    }
}
