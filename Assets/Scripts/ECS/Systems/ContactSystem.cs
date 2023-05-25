using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public class ContactSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerTag, MovableComponent> _filter;
        private ContactPoint2D[] contacts = new ContactPoint2D[5];
        private int counter;
        private float treshold = 0.2f;
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var player = ref _filter.Get1(i);
                ref var movableComponent = ref _filter.Get2(i);

                movableComponent._isGround = false;
                counter = player._playerView._collider.GetContacts(contacts);

                for (int j = 0; j < counter; j++)
                {
                    if (contacts[j].normal.y > treshold)
                        movableComponent._isGround = true;
                }

            }
        }
    }
}
