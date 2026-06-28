using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HKFeedback.Extensions;
using UnityEngine;

namespace HKFeedback.Actions
{
    [Serializable]
    public abstract class SubFeedback<TNewContext, TContext> : AsyncFeedback<TContext>
    {
        [SerializeReference, SubclassSelector]
        private IProvider<TNewContext> provider = null!;

        [SerializeReference, SubclassSelector]
        private IFeedback<TNewContext>[] feedbacks;

        protected override UniTask PlayInternalAsync(TContext context, CancellationToken cancellationToken)
        {
            return feedbacks.PlayAsync(provider.Provide(), cancellationToken);
        }
    }

    [Serializable]
    public sealed class SubFeedbackGameObject<TContext> : SubFeedback<GameObject, TContext> { }
}
