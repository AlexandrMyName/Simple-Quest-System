using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer2D
{
    [Serializable]
    public struct MovableComponent
    {
        public bool _isGround;
        public float _speedMove;
        public float _jumpForce;
        public float _treshold_X;
        public float _treshold_Y;
        public float _yVelocity;
        public float _xVelocity;
        public float _xAxisValue;
        public float _yAxisValue;
        public bool _isMooving;
        public bool _isJump;
        public float _animationSpeed;

    }
}
