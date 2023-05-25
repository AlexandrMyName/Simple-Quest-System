using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer2D
{
    public class QuestCoinModel : IQuestModel
    {
        public bool TryComplete(GameObject actor)
        {
            return actor.CompareTag("QuestCoin");
        }
    }
}
