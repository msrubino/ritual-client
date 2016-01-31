using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RitualTypeMappings : ScriptableObject 
{

    [System.Serializable]
    public class Mapping
    {
        public RitualType ritualType;
        public float duration;
        public RitualBehaviorBase ritualBehavior;
        public Button ritualChooseButton;
    }

    public Mapping[] mappings;

    public float GetDurationForType(RitualType ritualType)
    {
        var mapping = GetMappingForType(ritualType);
        if (mapping == null) return 0f;
        return mapping.duration;
    }

    public RitualBehaviorBase GetRitualBehaviorForType(RitualType ritualType)
    {
        var mapping = GetMappingForType(ritualType);
        if (mapping == null) return null;
        return mapping.ritualBehavior;
    }

    public Button GetButtonForType(RitualType ritualType)
    {
        var mapping = GetMappingForType(ritualType);
        if (mapping == null) return null;
        return mapping.ritualChooseButton;
    }

    public Mapping GetMappingForType(RitualType ritualType)
    {
        foreach (var mapping in mappings)
        {
            if (ritualType == mapping.ritualType)
            {
                return mapping;
            }
        }
        return null;
    }

}
