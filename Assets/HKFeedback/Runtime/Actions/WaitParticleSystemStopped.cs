using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;

namespace HKFeedback.Actions
{
    [Serializable]
    public class WaitParticleSystemStopped<T> : IFeedback<T> where T : IProvider<ParticleSystem>
    {
        public UniTask PlayAsync(T context, CancellationToken cancellationToken)
        {
            return context.Provide().GetAsyncParticleSystemStoppedTrigger().OnParticleSystemStoppedAsync(cancellationToken);
        }
    }
}
