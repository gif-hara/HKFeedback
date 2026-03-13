using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HKFeedback.Actions
{
    [Serializable]
    public class Update<T> : IFeedback<T>
    {
        [SerializeField]
        private PlayerLoopTiming timing = PlayerLoopTiming.Update;

        [SerializeReference, SubclassSelector]
        private IFeedback<T> feedback = null!;

        public async UniTask PlayAsync(T context, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await UniTask.Yield(timing, cancellationToken);
                await feedback.PlayAsync(context, cancellationToken);
            }
        }
    }
}
