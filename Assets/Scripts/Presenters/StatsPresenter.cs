namespace Lessons.Architecture.PM
{
    public class StatsPresenter:IStatsPresenter
    {
        public string[] StatNames { get; }
        public int[] StatValues { get; }

        public StatsPresenter(CharacterInfo characterInfo)
        {
            var massStats = characterInfo.GetStats();
            StatNames = new string[massStats.Length];
            StatValues = new int[massStats.Length];
            for (int i = 0; i < massStats.Length; i++)
            {
                StatNames[i] = massStats[i].Name;
                StatValues[i] = massStats[i].Value;
            }
        }
    }
}