using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class QuestController : IQuest
    {

        private InterectedObjectView _player;
        private QuestObjectView _questView;
        private bool _active;
        private IQuestModel _model;

        public bool IsCompleted { get; private set; }

        public event EventHandler<IQuest> QuestCompleted;


        public QuestController(InterectedObjectView player, IQuestModel model, QuestObjectView questView)
        {
            _player = player;
            _active = false;
            _model = model;
            _questView = questView;
            
        }

        public void Dispose()
        {
            _player.OnQuestCompleted -= OnContact;
        }

        public void Reset()
        {
            if(_active) return;
            _active = true;
            _player.OnQuestCompleted += OnContact;
            _questView.ProccessActivate();
            
        }
        public void OnContact(QuestObjectView questItem)
        {
            if(questItem == null) return;
            if (_model.TryComplete(questItem.gameObject))
            {
                if(questItem == _questView)
                {
                    Completed();
                }
            }
        }
        public void Completed()
        {
            if(!_active) return;
            _active = false;
            _player.OnQuestCompleted -= OnContact;
            _questView.ProccessComplete();
            QuestCompleted?.Invoke(this, this);
            
        }

 
    }
}
