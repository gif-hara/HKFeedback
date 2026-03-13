using UnityEngine;

namespace HKFeedback
{
    public interface IProvider<T>
    {
        T Provide();
    }
}
