using System;

namespace Tennis;

public class TennisGame3 : ITennisGame
{
    private int _player2Score;
    private int _player1Score;
    private string _player1Name;
    private string _player2Name;
    private const string Player1Name = "player1";
    private static readonly string[] ClassicScoreList = { "Love", "Fifteen", "Thirty", "Forty" };


    public TennisGame3(string player1Name, string player2Name)
    {
        this._player1Name = player1Name;
        this._player2Name = player2Name;
    }

    public string GetScore()
    {
        bool arePlayersScoreEquals = ArePlayersScoreEquals();
        const string allString = "-All";
        if (AreBothPlayerUnderFourPoint() && IsTotalScoreUnderSix())
        {
            string player1Score = ClassicScoreList[_player1Score];
            return arePlayersScoreEquals ? $"{player1Score}{allString}"
                : $"{player1Score}-{ClassicScoreList[_player2Score]}";
        }

        if (arePlayersScoreEquals)
            return "Deuce";
        string playerAboutToWin = PlayerAboutToWin();
        return AreScoreSeparatedByOnePoint()
            ? "Advantage " + playerAboutToWin
            : "Win for " + playerAboutToWin;
    }

    private bool AreScoreSeparatedByOnePoint()
    {
        return Math.Abs(_player1Score - _player2Score) == 1;
    }

    private string PlayerAboutToWin()
    {
        return _player1Score > _player2Score ? _player1Name : _player2Name;
    }

    private bool IsTotalScoreUnderSix()
    {
        return (_player1Score + _player2Score < 6);
    }

    private bool ArePlayersScoreEquals()
    {
        return (_player1Score == _player2Score);
    }

    private bool AreBothPlayerUnderFourPoint()
    {
        return (_player1Score < 4 && _player2Score < 4);
    }

    public void WonPoint(string playerName)
    {
        if (playerName == Player1Name)
            this._player1Score += 1;
        else
            this._player2Score += 1;
    }
}