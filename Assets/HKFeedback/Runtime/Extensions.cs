using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace HKFeedback.Extensions
{
    public static class Extensions
    {
        public static async UniTask PlayAsync<TContext>(this IEnumerable<IFeedback<TContext>> feedbacks, TContext context, CancellationToken cancellationToken)
        {
            foreach (var feedback in feedbacks)
            {
                await feedback.PlayAsync(context, cancellationToken);
            }
        }

        public static async UniTask PlayAsync<TContext>(this List<IFeedback<TContext>> feedbacks, TContext context, CancellationToken cancellationToken)
        {
            foreach (var feedback in feedbacks)
            {
                await feedback.PlayAsync(context, cancellationToken);
            }
        }

        public static async UniTask PlayAsync<TContext>(this IFeedback<TContext>[] feedbacks, TContext context, CancellationToken cancellationToken)
        {
            foreach (var feedback in feedbacks)
            {
                await feedback.PlayAsync(context, cancellationToken);
            }
        }

        public static bool EvaluateSafe<TContext>(this ICondition<TContext> condition, TContext context)
        {
            if (condition == null)
            {
                return true;
            }
            return condition.Evaluate(context);
        }
    }
}
