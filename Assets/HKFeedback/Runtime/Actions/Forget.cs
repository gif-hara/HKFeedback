using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HKFeedback.Actions
{
    [Serializable]
    public class Forget<T> : IFeedback<T>
    {
        [SerializeReference, SubclassSelector]
        private IFeedback<T> feedback = null!;

        public UniTask PlayAsync(T context, CancellationToken cancellationToken)
        {
            return feedback.PlayAsync(context, cancellationToken);
        }
    }
}
