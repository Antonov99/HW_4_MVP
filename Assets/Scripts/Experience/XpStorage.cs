using UniRx;

namespace Lessons.Architecture.PM
{
    public class XpStorage
    {
        public IReadOnlyReactiveProperty<long> Xp => _xp;
        private readonly ReactiveProperty<long> _xp;

        public XpStorage(long xp)
        {
            _xp = new ReactiveProperty<long>(xp);
        }
        
        public void AddXp(long xp)
        {
            _xp.Value += xp;
        }
        
        public void SpendXp(long xp)
        {
            _xp.SetValueAndForceNotify(xp);
        }
    }
}