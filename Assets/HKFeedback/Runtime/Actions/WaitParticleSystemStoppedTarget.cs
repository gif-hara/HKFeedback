using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;

namespace HKFeedback.Actions
{
    [Serializable]
    public class WaitParticleSystemStoppedTarget<T> : IFeedback<T>
    {
        [SerializeField]
        private ParticleSystem target = null;

        public UniTask PlayAsync(T context, CancellationToken cancellationToken)
        {
            return target.GetAsyncParticleSystemStoppedTrigger().OnParticleSystemStoppedAsync(cancellationToken);
        }
    }
}
