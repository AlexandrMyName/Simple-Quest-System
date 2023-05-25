using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer2D
{
    public class MovableSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerTag,MovableComponent> _filter;
        bool isInitialize = false;

        Vector3 leftScale = new Vector3(-1,1,1);
        Vector3 rightScale = new Vector3(1,1,1);
        public void Run()
        {
            if (!isInitialize)
            {
               
                isInitialize = true;
            }

            foreach (var i in _filter)
            {
                ref var playerView = ref _filter.Get1(i);
                ref var movableComponent = ref _filter.Get2(i);
                Move(ref movableComponent, ref playerView);
            }
        }

        public void Move(ref MovableComponent component, ref PlayerTag player)
        {
             component._yVelocity = player._playerView._rb.velocity.y;

             component._isMooving = Mathf.Abs(Input.GetAxis("Horizontal")) > component._treshold_X;
             component._isJump = Input.GetAxis("Vertical") > 0  || Input.GetKeyDown(KeyCode.Space);

            if (component._isMooving)
            {
                component._xVelocity = Time.fixedDeltaTime * component._speedMove * ( Input.GetAxis("Horizontal") > 0 ? 1 : -1);
                player._playerView._rb.velocity = new Vector2(component._xVelocity, component._yVelocity);
                player._playerView._transform.localScale = Input.GetAxis("Horizontal") > 0 ? rightScale : leftScale;
            }
            else
            {
                player._playerView._rb.velocity = new Vector2(0, component._yVelocity);
            }
            

            if (component._isJump && component._yVelocity == 0)
                player._playerView._rb.AddForce(Vector2.up * component._jumpForce, ForceMode2D.Impulse);
             
           
        }


        
    }
}
