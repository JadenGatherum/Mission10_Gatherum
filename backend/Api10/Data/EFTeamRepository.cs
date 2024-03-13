namespace Api10.Data
{
    public class EFTeamRepository: ITeamRepository
    {
        private BowlingLeagueContext _bowlingLeagueContext;
        public EFTeamRepository(BowlingLeagueContext temp)
        {
            _bowlingLeagueContext = temp;
        }
        public IEnumerable<Team> Teams => _bowlingLeagueContext.Teams;
    }
}
