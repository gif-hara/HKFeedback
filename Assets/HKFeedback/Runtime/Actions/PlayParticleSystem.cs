using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HKFeedback.Actions
{
    [Serializable]
    public class PlayParticleSystem<T> : IFeedback<T> where T : IProvider<ParticleSystem>
    {
        public UniTask PlayAsync(T context, CancellationToken cancellationToken)
        {
            context.Provide().Play();
            return UniTask.CompletedTask;
        }
    }
}
