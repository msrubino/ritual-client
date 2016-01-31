using System;

public class Ritual
{
    private RitualType _ritualType;
    public RitualType RitualType
    {
        get { return _ritualType; }
        set { _ritualType = value; }
    }

    private float _timeUntilStart;
    public float TimeUntilStart
    {
        get { return _timeUntilStart; }
        set { _timeUntilStart = value; }
    }

    private float _duration;
    public float Duration
    {
        get { return _duration; }
        set { _duration = value; }
    }
    
    private DateTime _startAt;
    public DateTime StartAt 
    {
        get { return _startAt; }
        set { _startAt = value; }
    }

    public bool IsActive
    {
        get
        {
            return DateTime.Now < StartAt.AddSeconds( Duration );
        }
    }
}
