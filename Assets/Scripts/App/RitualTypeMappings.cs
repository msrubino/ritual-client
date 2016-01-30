using UnityEngine;
using System.Collections;

public class RitualTypeMappings : ScriptableObject 
{

    [System.Serializable]
    public class Mapping
    {
        public RitualType ritualType;
        public Ritual ritual;
    }

    public Mapping[] mappings;

    public Ritual GetRitualForType(RitualType ritualType)
    {
        foreach (var mapping in mappings)
        {
            if (ritualType == mapping.ritualType)
            {
                return mapping.ritual;
            }
        }
        return null;
    }

}
