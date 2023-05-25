using Platformer2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class QuestConfigurator : MonoBehaviour
    {
        [SerializeField] private QuestObjectView _singleQuestView;
        [SerializeField] private InterectedObjectView _player;
        private QuestController _singleQuest;

        private void Start()
        {
            _singleQuest = new QuestController(_player, new QuestCoinModel(), _singleQuestView);
            _singleQuest.Reset();
        }
        private void OnDestroy()
        {
            _singleQuest.Dispose();   
        }
    }
}
