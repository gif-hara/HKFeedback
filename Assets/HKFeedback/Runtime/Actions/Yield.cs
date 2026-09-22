using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HKFeedback.Providers;
using UnityEngine;

namespace HKFeedback.Actions
{
    [Serializable]
    public class Yield<T> : IFeedback<T>
    {
        [SerializeReference, SubclassSelector]
        private IProvider<PlayerLoopTiming> playerLoopTiming = new Constant<PlayerLoopTiming>(PlayerLoopTiming.Update);

        [SerializeReference, SubclassSelector]
        private IProvider<bool> cancelImmediately = new Constant<bool>();

        public UniTask PlayAsync(T context, CancellationToken cancellationToken)
        {
            return UniTask.Yield(playerLoopTiming.Provide(), cancellationToken, cancelImmediately.Provide());
        }
    }
}
