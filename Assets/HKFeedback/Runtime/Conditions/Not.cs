using System;
using UnityEngine;

namespace HKFeedback.Conditions
{
    [Serializable]
    public class Not<TContext> : ICondition<TContext>
    {
        [SerializeReference, SubclassSelector]
        private ICondition<TContext> condition;

        public bool Evaluate(TContext context) => !condition.Evaluate(context);
    }
}
