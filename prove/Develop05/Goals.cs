using System;

namespace EternalQuestProgram
{
    abstract class Goal
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public bool IsComplete { get; protected set; }

        public Goal(string name, int points)
        {
            Name = name;
            Points = points;
            IsComplete = false;
        }

        public abstract void RecordEvent();
    }
}
