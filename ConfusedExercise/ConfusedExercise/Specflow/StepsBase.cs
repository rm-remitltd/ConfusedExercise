using System;
using TechTalk.SpecFlow;

namespace ConfusedExercise.Specflow
{
    internal abstract class StepsBase : Steps
    {
        internal void Save<TObj>(TObj obj) => ScenarioContext.Add(typeof(TObj).FullName, obj);

        internal TObj Retrieve<TObj>() => ScenarioContext.Get<TObj>(typeof(TObj).FullName);

        internal Tuple<T1,T2> Retrieve<T1, T2>() => Tuple.Create(Retrieve<T1>(), Retrieve<T2>());
    }
}
