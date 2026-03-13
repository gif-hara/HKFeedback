using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HKFeedback.Actions
{
    public class Log<T> : IFeedback<T>
    {
        [SerializeField]
        private string message = null!;

        public UniTask PlayAsync(T context, CancellationToken cancellationToken)
        {
            Debug.Log(message);
            return UniTask.CompletedTask;
        }
    }
}
