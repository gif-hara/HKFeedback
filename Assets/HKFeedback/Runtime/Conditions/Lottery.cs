using System;
using UnityEngine;

namespace HKFeedback.Conditions
{
    [Serializable]
    public class Lottery<TContext> : ICondition<TContext>
    {
        [SerializeReference, SubclassSelector]
        private IProvider<float> probability = new Providers.Constant<float>();

        public bool Evaluate(TContext context) => UnityEngine.Random.value <= probability.Provide();
    }
}
