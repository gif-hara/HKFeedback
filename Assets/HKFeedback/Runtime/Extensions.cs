using System.Threading;
using Cysharp.Threading.Tasks;

namespace HKFeedback.Extensions
{
    public static class Extensions
    {
        public static UniTask PlayAsync<TContext>(this IFeedback<TContext> feedback, TContext context, CancellationToken cancellationToken)
        {
            return feedback.PlayAsync(context, cancellationToken);
        }
    }
}
