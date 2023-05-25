using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Platformer2D
{
    public enum AnimationState { Idle,Run,Jump }

    [CreateAssetMenu(fileName = "AnimCnf", menuName = "Configs/Animations/Simple_cnf",order = 1)]
    public class AnimatorConfig : ScriptableObject
    {
        [Serializable]
        public class AnimationSequences
        {
            public List<Sprite> sprites = new List<Sprite>();
            public AnimationState track;
        }
        public List<AnimationSequences> _animations;
    }
}

