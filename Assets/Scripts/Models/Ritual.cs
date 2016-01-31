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
    public DateTime StartsAt 
    {
        get { return _startAt; }
        set { _startAt = value; }
    }

    public bool IsActive
    {
        get
        {
            return DateTime.Now < StartsAt.AddSeconds( Duration );
        }
    }

    public static Ritual FromRitualObj( RitualObj obj ) 
    {
        Ritual newRitual = new Ritual();
        newRitual.Duration = obj.duration;
        newRitual.RitualType = (RitualType)obj.ritual_type;
        newRitual.StartsAt = DateTime.Parse( obj.starts_at );
        newRitual.TimeUntilStart = obj.time_until_start;

        return newRitual;
    }
}
