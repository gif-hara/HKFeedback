using System;
using UnityEngine;

namespace HKFeedback.Providers
{
    [Serializable]
    public class Constant<TContext> : IProvider<TContext>, IProvider<IProvider<TContext>>
    {
        [SerializeField]
        private TContext context;

        public Constant()
        {
        }

        public Constant(TContext context)
        {
            this.context = context;
        }

        TContext IProvider<TContext>.Provide() => context;

        IProvider<TContext> IProvider<IProvider<TContext>>.Provide() => this;
    }
}
