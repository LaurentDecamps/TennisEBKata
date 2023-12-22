namespace Tennis;

public class TennisGame1 : ITennisGame
{
    private int _mScore1;
    private int _mScore2;
    private string player1Name;
    private string player2Name;

    public TennisGame1(string player1Name, string player2Name)
    {
        this.player1Name = player1Name;
        this.player2Name = player2Name;
    }

    public void WonPoint(string playerName)
    {
        if (playerName == "player1")
            _mScore1 += 1;
        else
            _mScore2 += 1;
    }

    public string GetScore()
    {
        if (IsScoreEqual())
        {
            return GetEqualityScore();
        }

        return IsOneScorePossiblyWin() ? 
                GetAdvantageOrWin() : 
                GetNonEqualityAdvantageOrWinScore();
    }

    private bool IsOneScorePossiblyWin()
    {
        return _mScore1 >= 4 || _mScore2 >= 4;
    }

    private bool IsScoreEqual()
    {
        return _mScore1 == _mScore2;
    }

    private string GetNonEqualityAdvantageOrWinScore()
    {
        return $"{GetNormalScore(_mScore1)}-{GetNormalScore(_mScore2)}";
    }

    private static string GetNormalScore(int score)
    {
        return score switch
        {
            0 => "Love",
            1 => "Fifteen",
            2 => "Thirty",
            3 => "Forty",
            _ => "error"
        };
    }

    private string GetAdvantageOrWin()
    {
        var minusResult = _mScore1 - _mScore2;
        switch (minusResult)
        {
            case 1:
                return "Advantage player1";
            case -1:
                return "Advantage player2";
            case >= 2:
                return "Win for player1";
            default:
                return "Win for player2";
        }
    }

    private string GetEqualityScore()
    {
        switch (_mScore1)
        {
            case 0:
                return "Love-All";
            case 1:
                return "Fifteen-All";
            case 2:
                return "Thirty-All";
            default:
                return "Deuce";
        }
    }
}