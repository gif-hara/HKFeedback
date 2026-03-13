using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HKFeedback.Actions
{
    [Serializable]
    public class SetActiveGameObjectTarget<T> : IFeedback<T>
    {
        [SerializeField]
        private GameObject target = null!;

        [SerializeField]
        private bool isActive = true;

        public UniTask PlayAsync(T context, CancellationToken cancellationToken)
        {
            target.SetActive(isActive);
            return UniTask.CompletedTask;
        }
    }
}
