using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer2D
{
    public interface IQuestStoryModel : IDisposable
    {
       bool IsDone { get; }
    }
}
