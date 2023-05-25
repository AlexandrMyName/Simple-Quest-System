using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer2D
{
    public enum StoryType
    {
        Common,
        Resettable
    }



    [CreateAssetMenu(fileName = "QuestStoryConfig", menuName = "Configs/QuestSystem/QuestStoryCnf", order = 1)]
    public class QuestStoryConfig : ScriptableObject
    {
        public QuestConfig[] QuestConfigs; 
        public StoryType storyType;
    }
}
