using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HKFeedback.Providers;
using UnityEngine;

namespace HKFeedback.Actions
{
    [Serializable]
    public class UpdateAnimator<T> : IFeedback<T> where T : IProvider<Animator>
    {
        [SerializeReference, SubclassSelector]
        private IProvider<float> deltaTime = new Constant<float>();

        public UniTask PlayAsync(T context, CancellationToken cancellationToken)
        {
            context.Provide().Update(deltaTime.Provide());
            return UniTask.CompletedTask;
        }
    }
}
