using UniRx;
using System;

public class SuccessCount
{
    ReactiveProperty<int> success = new IntReactiveProperty(0);
    public IReadOnlyReactiveProperty<int> successProperty => success;

    public void AddSuccessCount(int count = 1)
    {
        if (count <= 0)
            throw new ArgumentOutOfRangeException("¬Œ÷‚µ‚½‰ñ”‚Í³‚Ì®”‚Å‚È‚¯‚ê‚Î‚¢‚¯‚Ü‚¹‚ñ.");

        success.Value += count;
    }
}
