using System;

namespace Scripts
{
    public class GameStatistics
    {
        public TimeSpan RemainingTime { get; set; }
        public int CollectedDangerousItems { get; set; }
        public int AllDangerousItemsOnScene { get; set; }
        public int CollectedBasicItems { get; set; }
    }
}
