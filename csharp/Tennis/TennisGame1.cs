using System;
using static System.Formats.Asn1.AsnWriter;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int player1Score = 0;
        private int player2Score = 0;
        private string player1Name;
        private string player2Name;
        private const string love = "Love";
        private const string fifteen = "Fifteen";
        private const string thirty = "Thirty";
        private const string forty = "Forty";
        private const string deuce = "Deuce";
        private const string advantage = "Advantage ";
        private const string win = "Win for ";
        private const string space = "-";
        private const string all = "All";
        private string[] scores = { love, fifteen, thirty, forty };

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == player1Name)
                player1Score += 1;
            else
                player2Score += 1;
        }
        public string GetScore()
        {
            int difference = player1Score - player2Score;
            bool canBeWon = Math.Max(player1Score, player2Score)>=4;
            if (difference == 0)
            {
                return GetSameScore();
            }
            if (canBeWon)
            {
                return GetAdvantageOrWin(difference);
            }
            return GetNotSameSmallScore();
        }

        private string GetNotSameSmallScore()
        {
            return scores[player1Score] + space + scores[player2Score];
        }

        private string GetAdvantageOrWin(int difference)
        {
            string leadingPlayerName;
            if (difference > 0)
                leadingPlayerName = player1Name;
            else
                leadingPlayerName = player2Name;
            if (Math.Abs(difference) == 1)
                return advantage + leadingPlayerName;
            else
                return win + leadingPlayerName;
        }

        private string GetSameScore()
        {
            if (player1Score >= 3)
                return deuce;
            else
                return scores[player1Score] + space + all;
        }
    }
}

