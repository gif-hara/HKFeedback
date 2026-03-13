using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HKFeedback.Actions
{
    public class SetParent<T> : IFeedback<T> where T : IProvider<Transform>
    {
        [SerializeField]
        private Transform parent = null!;

        public UniTask PlayAsync(T context, CancellationToken cancellationToken)
        {
            context.Provide().SetParent(parent);
            return UniTask.CompletedTask;
        }
    }
}
