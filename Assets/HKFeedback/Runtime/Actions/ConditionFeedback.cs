using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HKFeedback.Extensions;
using UnityEngine;

namespace HKFeedback.Actions
{
    [Serializable]
    public class ConditionFeedback<T> : IFeedback<T>
    {
        [SerializeField]
        private ICondition<T> condition;

        [SerializeField]
        private IFeedback<T>[] feedbacks;

        public UniTask PlayAsync(T context, CancellationToken cancellationToken)
        {
            if (condition.Evaluate(context))
            {
                return feedbacks.PlayAsync(context, cancellationToken);
            }
            else
            {
                return UniTask.CompletedTask;
            }
        }
    }
}
