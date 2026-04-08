using System;
using UnityEngine;

namespace HKFeedback.Conditions
{
    [Serializable]
    public class CompareTag<TContext> : ICondition<TContext> where TContext : IProvider<GameObject>
    {
        [SerializeField]
        private string tag;

        public bool Evaluate(TContext context) => context.Provide().CompareTag(tag);
    }
}
