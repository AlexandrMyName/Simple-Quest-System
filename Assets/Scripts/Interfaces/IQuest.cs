using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public interface IQuest : IDisposable
    {
        event EventHandler<IQuest> QuestCompleted;
        bool IsCompleted { get; }

        void Reset();
    }
}
