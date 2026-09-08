using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HKFeedback.Providers;
using UnityEngine;

namespace HKFeedback.Actions
{
    [Serializable]
    public class SetTriggerAnimator<T> : IFeedback<T> where T : IProvider<Animator>
    {
        [SerializeReference, SubclassSelector]
        private IProvider<PropertyName> propertyName = new Constant<PropertyName>();

        public UniTask PlayAsync(T context, CancellationToken cancellationToken)
        {
            context.Provide().SetTrigger(propertyName.Provide().GetHashCode());
            return UniTask.CompletedTask;
        }
    }
}
