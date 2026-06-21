using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HKFeedback.Actions
{
    [Serializable]
    public abstract class AsyncFeedback<T> : IFeedback<T>
    {
        [SerializeField]
        private bool forget = false;

        public async UniTask PlayAsync(T context, CancellationToken cancellationToken)
        {
            if (forget)
            {
                PlayInternalAsync(context, cancellationToken).Forget();
            }
            else
            {
                await PlayInternalAsync(context, cancellationToken);
            }
        }

        protected abstract UniTask PlayInternalAsync(T context, CancellationToken cancellationToken);
    }
}
