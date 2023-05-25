using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{

    [CreateAssetMenu(fileName = "QuestItemConfig", menuName = "Configs/QuestSystem/QuestItemCnf", order = 1)]
    public class QuestItemConfig : ScriptableObject
    {
        public int questID;
        public List<int> questItemID;
    }
}