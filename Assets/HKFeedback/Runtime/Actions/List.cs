using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HKFeedback.Extensions;
using UnityEngine;

namespace HKFeedback.Actions
{
    [Serializable]
    public class List<T> : IFeedback<T>
    {
        [SerializeReference, SubclassSelector]
        private System.Collections.Generic.List<IFeedback<T>> feedbacks = null!;

        public UniTask PlayAsync(T context, CancellationToken cancellationToken)
        {
            return feedbacks.PlayAsync(context, cancellationToken);
        }
    }
}
