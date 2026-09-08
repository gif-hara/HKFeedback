using System;
using UnityEngine;

namespace HKFeedback.Providers
{
    [Serializable]
    public abstract class RandomRange<TContext> : IProvider<TContext>, IProvider<IProvider<TContext>>
    {
        [SerializeReference, SubclassSelector]
        protected IProvider<TContext> min = new Constant<TContext>();

        [SerializeReference, SubclassSelector]
        protected IProvider<TContext> max = new Constant<TContext>();

        TContext IProvider<TContext>.Provide() => Provide();

        IProvider<TContext> IProvider<IProvider<TContext>>.Provide() => this;

        protected abstract TContext Provide();
    }

    [Serializable]
    public sealed class RandomRangeInt : RandomRange<int>
    {
        protected override int Provide() => UnityEngine.Random.Range(min.Provide(), max.Provide());
    }

    [Serializable]
    public sealed class RandomRangeFloat : RandomRange<float>
    {
        protected override float Provide() => UnityEngine.Random.Range(min.Provide(), max.Provide());
    }

    [Serializable]
    public sealed class RandomRangeVector2 : RandomRange<Vector2>
    {
        protected override Vector2 Provide()
        {
            var min = this.min.Provide();
            var max = this.max.Provide();
            return new Vector2(
                UnityEngine.Random.Range(min.x, max.x),
                UnityEngine.Random.Range(min.y, max.y)
            );
        }
    }

    [Serializable]
    public sealed class RandomRangeVector3 : RandomRange<Vector3>
    {
        protected override Vector3 Provide()
        {
            var min = this.min.Provide();
            var max = this.max.Provide();
            return new Vector3(
                UnityEngine.Random.Range(min.x, max.x),
                UnityEngine.Random.Range(min.y, max.y),
                UnityEngine.Random.Range(min.z, max.z)
            );
        }
    }
}

