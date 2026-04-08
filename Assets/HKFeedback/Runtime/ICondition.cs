namespace HKFeedback
{
    public interface ICondition<TContext>
    {
        bool Evaluate(TContext context);
    }
}
