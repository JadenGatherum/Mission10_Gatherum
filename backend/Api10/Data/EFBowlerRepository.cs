using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Api10.Data
{
    public class EFBowlerRepository: IBowlerRepository
    {
        private BowlingLeagueContext _bowlingLeagueContext;
        public EFBowlerRepository(BowlingLeagueContext temp)
        {
            _bowlingLeagueContext = temp;
        }
        public IEnumerable<Bowler> Bowlers => _bowlingLeagueContext.Bowlers;
    }
}
