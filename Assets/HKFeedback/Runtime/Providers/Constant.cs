using System;
using UnityEngine;

namespace HKFeedback.Providers
{
    [Serializable]
    public class Constant<TContext> : IProvider<TContext>
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

        public TContext Provide() => context;
    }
}
