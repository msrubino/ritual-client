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

    public RitualBehaviorBase GetRitualForType(RitualType ritualType)
    {
        foreach (var mapping in mappings)
        {
            if (ritualType == mapping.ritualType)
            {
                return mapping.ritualBehavior;
            }
        }
        return null;
    }

}
