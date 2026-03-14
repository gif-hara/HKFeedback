using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HKFeedback.Actions
{
    [Serializable]
    public class Delay<T> : IFeedback<T>
    {
        [SerializeField, Min(0f)]
        private float delay = 1f;

        public UniTask PlayAsync(T context, CancellationToken cancellationToken)
        {
            return UniTask.Delay(TimeSpan.FromSeconds(delay), cancellationToken: cancellationToken);
        }
    }
}
