using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HKFeedback.Actions
{
    [Serializable]
    public class SetActiveGameObject<T> : IFeedback<T> where T : IProvider<GameObject>
    {
        [SerializeField]
        private bool isActive = true;

        public UniTask PlayAsync(T context, CancellationToken cancellationToken)
        {
            context.Provide().SetActive(isActive);
            return UniTask.CompletedTask;
        }
    }
}
