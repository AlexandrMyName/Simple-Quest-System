using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class SimpleAnimator : IDisposable
    {
        public class Animation
        {
            public bool isSleep;
            public bool isLoop;
            public List<Sprite> sprites = new List<Sprite>();
            public AnimationState track;
            public float speed;
            public float counter;

            public void Update()
            {
                if(isSleep) return;
                counter+= Time.deltaTime * speed;

                if (isLoop)
                {
                    while(counter > sprites.Count)
                    {
                        counter -= sprites.Count;
                    }
                }
                else if(counter > sprites.Count)
                {
                    counter = sprites.Count;
                    isSleep = true;
                }
            }
        }
        private Dictionary<SpriteRenderer, Animation> _activeAnimations = new Dictionary<SpriteRenderer, Animation>();
        private AnimatorConfig _config;

        public SimpleAnimator(AnimatorConfig config)
        {
            _config = config;
        }



        public void Start(SpriteRenderer renderer, bool isLoop, float speed, AnimationState track)
        {
            if(_activeAnimations.TryGetValue(renderer, out var animation))
            {
                if(animation.track != track)
                {
                    animation.track = track;
                    animation.sprites = _config._animations.Find(x => x.track == track).sprites;

                    animation.counter = 0;
                    animation.isSleep = false;
                }

                animation.isLoop = isLoop;
                animation.speed = speed;
                

            }
            else
            {
                _activeAnimations.Add(renderer, new Animation()
                {
                    isSleep = false,
                    track = track,
                    sprites = _config._animations.Find(x => x.track == track).sprites,
                    counter = 0,
                    isLoop = isLoop,
                    speed = speed
            });
            }
        }
        public void Stop(SpriteRenderer renderer)
        {
            if(_activeAnimations.ContainsKey(renderer))
                _activeAnimations.Remove(renderer);
        }

        public void Update()
        {
            foreach(var animation in _activeAnimations)
            {
                animation.Value.Update();

                if(animation.Value.counter < animation.Value.sprites.Count)
                {
                    animation.Key.sprite = animation.Value.sprites[(int)animation.Value.counter];
                }
            }
        }

        public void Dispose() => _activeAnimations.Clear();
        
    }
}
