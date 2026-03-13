using UnityEngine;

namespace HKFeedback.Examples
{
    public class Example : MonoBehaviour
    {
        [SerializeReference, SubclassSelector]
        private IFeedback<Example> feedback = null!;
    }
}
