using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public enum QuestType
    {
        Coins,
        Buttons
    }

    [CreateAssetMenu(fileName = "QuestConfig", menuName = "Configs/QuestSystem/QuestCnf", order = 1)]
    public class QuestConfig : ScriptableObject
    {
        public int questID;
        public QuestType type;
    }
}