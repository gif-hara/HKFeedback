using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HKFeedback.Extensions;
using UnityEngine;

namespace HKFeedback.Actions
{
    [Serializable]
    public class WaitUntil<T> : IFeedback<T>
    {
        [SerializeReference, SubclassSelector]
        private ICondition<T> condition;

        public UniTask PlayAsync(T context, CancellationToken cancellationToken) => UniTask.WaitUntil((this, context), static state => state.Item1.condition.EvaluateSafe(state.context));
    }
}
