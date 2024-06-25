using UnityEngine;

namespace Scripts
{
    [CreateAssetMenu(menuName = "GameSettings/DifficultPreset", fileName = "New Difficult")]
    public class GameDifficult : ScriptableObject
    {
        public string GameDifficultLevelName;
        public int timeInSecondToFindAllDangerousItems;
        public int fromDangerousObjectsCount;
        public int toDangerousObjectsCount;
    }
}


