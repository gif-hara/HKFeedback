using System;
using UnityEngine;

namespace HKFeedback.Conditions
{
    [Serializable]
    public class Constant<TContext> : ICondition<TContext>
    {
        [SerializeField]
        private bool value;

        public bool Evaluate(TContext context) => value;
    }
}
