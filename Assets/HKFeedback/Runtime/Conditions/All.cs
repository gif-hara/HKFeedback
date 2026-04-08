using System;
using UnityEngine;

namespace HKFeedback.Conditions
{
    [Serializable]
    public class All<TContext> : ICondition<TContext>
    {
        [SerializeField]
        private ICondition<TContext>[] conditions;

        public bool Evaluate(TContext context)
        {
            foreach (var condition in conditions)
            {
                if (!condition.Evaluate(context))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
