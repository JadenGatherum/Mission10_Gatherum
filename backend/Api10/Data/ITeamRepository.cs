namespace Api10.Data
{
    public interface ITeamRepository
    {
        IEnumerable<Team> Teams { get; }
    }
}
