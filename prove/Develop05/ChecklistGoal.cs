using System;

namespace EternalQuestProgram
{
    class ChecklistGoal : Goal
    {
        public int CompletedCount { get; private set; }
        public int TargetCount { get; }

        public ChecklistGoal(string name, int points, int targetCount) : base(name, points)
        {
            TargetCount = targetCount;
            CompletedCount = 0;
        }

        public override void RecordEvent()
        {
            CompletedCount++;

            if (CompletedCount >= TargetCount)
            {
                IsComplete = true;
            }
        }
    }
}
