using System;

/// <summary>
/// Simple class to store a high score consisting of the score, the player who achieved the score, and the date that
/// they achieved the score (so we can have best score in the last day/week/month etc.).
/// </summary>
public class HighscoreRecord
{
    public int _score;
    public string _player;
    public DateTime _date;
}
