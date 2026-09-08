using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HKFeedback.Providers;
using UnityEngine;

namespace HKFeedback.Actions
{
    [Serializable]
    public class SetFloatAnimator<T> : IFeedback<T> where T : IProvider<Animator>
    {
        [SerializeReference, SubclassSelector]
        private IProvider<PropertyName> propertyName = new Constant<PropertyName>();

        [SerializeReference, SubclassSelector]
        private IProvider<float> value = new Constant<float>();

        public UniTask PlayAsync(T context, CancellationToken cancellationToken)
        {
            context.Provide().SetFloat(propertyName.Provide().GetHashCode(), value.Provide());
            return UniTask.CompletedTask;
        }
    }
}
