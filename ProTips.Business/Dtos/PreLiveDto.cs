using ProTips.Entity.Utils;

namespace ProTips.Business.Dtos;

public class PreLiveDto
{
    public int GameId { get; set; }
    public decimal HomeOdd { get; set; }
    public decimal DrawOdd { get; set; }
    public decimal AwayOdd { get; set; }
    public decimal AvgGoalsHomeAtHome { get; set; }
    public decimal AvgGoalsAwayAtAway { get; set; }
    public decimal AvgGoalsHomeVsAway { get; set; }
    public decimal AvgGoalsHalfTime { get; set; }
    public decimal AvgOver1_5GoalsHome { get; set; }
    public decimal AvgOver1_5GoalsAway { get; set; }
    public decimal AvgUnder2_5GoalsHome { get; set; }
    public decimal AvgUnder2_5GoalsAway { get; set; }
    public decimal AvgUnder3_5GoalsHome { get; set; }
    public decimal AvgUnder3_5GoalsAway { get; set; }
    public decimal AvgGoalsMomentHome { get; set; }
    public decimal AvgGoalsMomentAway { get; set; }
    public string PossibleResults { get; set; }
    public decimal AvgBothTeamsToScoreHome { get; set; }
    public decimal AvgBothTeamsToScoreAway { get; set; }
    public GameRelevance GameRelevance { get; set; }
    public int? NeedVictoryTeamId { get; set; }
}