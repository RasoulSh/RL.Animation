﻿using RL.Animation.Motion.Base;
using UnityEngine;
using UnityEngine.Animations;

namespace RL.Animation.Motion.Misc
{
    public class RotateAroundSelf : AutoMotion
    {
        [SerializeField]
        private Axis axis;

        public RotateAroundSelf Initialize(Axis axis, AutoMotionData data)
        {
            Initialize(data);
            this.axis = axis;
            return this;
        }

        protected override void UpdateMotion(float progress)
        {
            var euler = thisTransform == null ? transform.localEulerAngles :
                thisTransform.localEulerAngles;
            var axisInt = (int)axis;
            var t = Mathf.Lerp(0f, 359f, progress);
            switch (axisInt)
            {
                case 1:
                    euler[0] = t;
                    break;
                case 2:
                    euler[1] = t;
                    break;
                case 4:
                    euler[2] = t;
                    break;
                case 3:
                    euler[0] = t;
                    euler[1] = t;
                    break;
                case 5:
                    euler[0] = t;
                    euler[2] = t;
                    break;
                case 6:
                    euler[1] = t;
                    euler[2] = t;
                    break;
                case 7:
                    euler[0] = t;
                    euler[1] = t;
                    euler[2] = t;
                    break;
            }
            if (thisTransform != null)
                thisTransform.localEulerAngles = euler;
            else
                transform.localEulerAngles = euler;
        }
    }
}
