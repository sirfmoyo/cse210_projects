using System;

namespace EternalQuestProgram
{
    class SimpleGoal : Goal
    {
        public SimpleGoal(string name, int points) : base(name, points)
        {
        }

        public override void RecordEvent()
        {
            IsComplete = true;
        }
    }
}
