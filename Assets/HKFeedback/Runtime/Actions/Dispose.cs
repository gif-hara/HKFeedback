using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace HKFeedback.Actions
{
    [Serializable]
    public class Dispose<T> : IFeedback<T> where T : IProvider<IDisposable>
    {
        public UniTask PlayAsync(T context, CancellationToken cancellationToken)
        {
            context.Provide().Dispose();
            return UniTask.CompletedTask;
        }
    }
}
