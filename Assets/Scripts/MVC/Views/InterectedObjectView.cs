using Platformer2D;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class InterectedObjectView : LevelObjectView
    {
        public Action<QuestObjectView> OnQuestCompleted { get; set; }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out LevelObjectView ContactView))
            {
                if(ContactView != null)
                {
                    if(ContactView is QuestObjectView)
                    {
                        OnQuestCompleted?.Invoke((QuestObjectView)ContactView);
                    }
                }
            }
        }
    }
}
