using System;

namespace EternalQuestProgram
{
    class EternalGoal : Goal
    {
        public EternalGoal(string name, int points) : base(name, points)
        {
        }

        public override void RecordEvent()
        {
            // Do nothing for eternal goals
        }
    }
}
