using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Voody.UniLeo;

namespace Platformer2D
{
    public class ECS_StartUp : MonoBehaviour
    {
       private EcsWorld _world = null;
       private EcsSystems _systems = null;



        void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            AddSystems();

            _systems.ConvertScene();
            _systems.Init();
        }

         
        void Update()
        {
            _systems.Run();
        }


        private void AddSystems()
        {
            _systems.Add(new AnimatorSystem()).Add(new MovableSystem()).Add(new ContactSystem());
        }
    }
}
