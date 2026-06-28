using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HKFeedback.Extensions;
using UnityEngine;

namespace HKFeedback.Actions
{
    [Serializable]
    public abstract class SubFeedbackAsync<TNewContext, TContext> : AsyncFeedback<TContext>
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

    [Serializable] public sealed class SubFeedbackGameObject<TContext> : SubFeedbackAsync<GameObject, TContext> { }
    [Serializable] public sealed class SubFeedbackTransform<TContext> : SubFeedbackAsync<Transform, TContext> { }
    [Serializable] public sealed class SubFeedbackRectTransform<TContext> : SubFeedbackAsync<RectTransform, TContext> { }
    [Serializable] public sealed class SubFeedbackParticleSystem<TContext> : SubFeedbackAsync<ParticleSystem, TContext> { }
    [Serializable] public sealed class SubFeedbackRigidbody<TContext> : SubFeedbackAsync<Rigidbody, TContext> { }
    [Serializable] public sealed class SubFeedbackRigidbody2D<TContext> : SubFeedbackAsync<Rigidbody2D, TContext> { }
}
