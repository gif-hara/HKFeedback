using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HKFeedback.Actions
{
    [Serializable]
    public class SetAlphaCanvasGroup<T> : IFeedback<T> where T : IProvider<CanvasGroup>
    {
        [SerializeField]
        private float alpha = default!;

        public UniTask PlayAsync(T context, CancellationToken cancellationToken)
        {
            context.Provide().alpha = alpha;
            return UniTask.CompletedTask;
        }
    }
}
