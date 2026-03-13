using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HKFeedback.Actions
{
    [Serializable]
    public class SyncTransform<T> : IFeedback<T> where T : IProvider<Transform>
    {
        [SerializeField]
        private Transform target = null!;

        [SerializeField]
        private bool syncPosition = true;

        [SerializeField]
        private bool syncRotation = true;

        [SerializeField]
        private bool syncScale = true;

        public UniTask PlayAsync(T context, CancellationToken cancellationToken)
        {
            var transform = context.Provide();
            if (syncPosition)
            {
                transform.position = target.position;
            }
            if (syncRotation)
            {
                transform.rotation = target.rotation;
            }
            if (syncScale)
            {
                transform.localScale = target.lossyScale;
            }
            return UniTask.CompletedTask;
        }
    }
}
