using Cysharp.Threading.Tasks;
using HKFeedback.Extensions;
using UnityEngine;

namespace HKFeedback.Examples
{
    public class Example : MonoBehaviour, IProvider<Transform>
    {
        [SerializeReference, SubclassSelector]
        private IFeedback<Example>[] feedbacks = null!;

        Transform IProvider<Transform>.Provide() => transform;

        void Start()
        {
            feedbacks.PlayAsync(this, default).Forget();
        }
    }
}
