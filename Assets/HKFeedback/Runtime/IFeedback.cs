using System.Threading;
using Cysharp.Threading.Tasks;

namespace HKFeedback
{
    public interface IFeedback<TContext>
    {
        UniTask PlayAsync(TContext context, CancellationToken cancellationToken);
    }
}
