using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer2D
{
    public class QuestObjectView : LevelObjectView
    {
        public Color _completedColor;
        public Color _defaultColor;


        public void Awake()
        {
            _defaultColor = _spriteRenderer.color;
        }

        public void ProccessComplete()
        {
            _spriteRenderer.color = _completedColor;
        }
        public void ProccessActivate()
        {
            _spriteRenderer.color = _defaultColor;
        }
    }

}
