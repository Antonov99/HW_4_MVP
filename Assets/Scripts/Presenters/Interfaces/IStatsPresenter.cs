namespace Lessons.Architecture.PM
{
    public interface IStatsPresenter:IPresenter
    {
        public string[] StatNames { get; }
        public int[] StatValues { get; }
    }
}