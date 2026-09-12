using System;
using UnityEngine;

namespace HKFeedback.Providers
{
    [Serializable]
    public class DeltaTime : IProvider<float>, IProvider<IProvider<float>>
    {
        public DeltaTime()
        {
        }

        float IProvider<float>.Provide() => Time.deltaTime;

        IProvider<float> IProvider<IProvider<float>>.Provide() => this;
    }
}
