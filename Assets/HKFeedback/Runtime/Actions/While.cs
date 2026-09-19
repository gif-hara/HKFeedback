using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HKFeedback.Extensions;
using UnityEngine;

namespace HKFeedback.Actions
{
    [Serializable]
    public class While<T> : AsyncFeedback<T>
    {
        [SerializeField]
        private IFeedback<T>[] feedbacks = null!;

        protected override async UniTask PlayInternalAsync(T context, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await feedbacks.PlayAsync(context, cancellationToken);
            }
        }
    }
}
