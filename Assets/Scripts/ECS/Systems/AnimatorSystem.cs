using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Platformer2D
{
    public class AnimatorSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerTag,MovableComponent> _filter;
        private AnimatorConfig _playerConfig;
        private SimpleAnimator _playerAnimator; 

        bool isInitialize = false;
        public void Run() 
        {
            if (!isInitialize){
                _playerConfig = Resources.Load<AnimatorConfig>("PlayerAnimCnf");
                _playerAnimator = new SimpleAnimator(_playerConfig);
                isInitialize = true;
            }

            foreach(var i in _filter)
            {
                ref var playerView = ref _filter.Get1(i);
                ref var movableComponent = ref _filter.Get2(i);
                CheckOutAnimations(ref movableComponent,ref playerView);
            }
        }

        public void CheckOutAnimations(ref MovableComponent component, ref PlayerTag player)
        {
            _playerAnimator.Update();
            if (component._isGround  )
            {
                _playerAnimator.Start(player._playerView._spriteRenderer, true, component._animationSpeed, component._isMooving ? AnimationState.Run : AnimationState.Idle);
            }
            else if(Mathf.Abs(component._yVelocity) > component._treshold_Y)
            {
                
                    _playerAnimator.Start(player._playerView._spriteRenderer, false, component._animationSpeed, AnimationState.Jump);
                

            }
            
        }
    }
}
