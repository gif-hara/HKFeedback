using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace HKFeedback.Actions
{
    [Serializable]
    public class SetColorGraphic<T> : IFeedback<T> where T : IProvider<Graphic>
    {
        [SerializeField]
        private Color color = default!;

        public UniTask PlayAsync(T context, CancellationToken cancellationToken)
        {
            context.Provide().color = color;
            return UniTask.CompletedTask;
        }
    }
}
