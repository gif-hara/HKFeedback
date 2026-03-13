using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HKFeedback.Actions
{
    [Serializable]
    public class Destroy<T> : IFeedback<T> where T : IProvider<GameObject>
    {
        public UniTask PlayAsync(T context, CancellationToken cancellationToken)
        {
            UnityEngine.Object.Destroy(context.Provide());
            return UniTask.CompletedTask;
        }
    }
}
