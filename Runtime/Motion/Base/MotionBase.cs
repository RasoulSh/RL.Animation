﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RL.Animation.Motion.Base
{
    public abstract class MotionBase : MonoBehaviour
    {
        [Range(0f, 1f)]
        [SerializeField]
        protected float progress = 0f;
        protected Transform thisTransform { get; private set; }

        private void Awake()
        {
            thisTransform = transform;
            UpdateMotion(progress);
        }

        private void OnValidate()
        {
            UpdateMotion(progress);
        }

        protected abstract void UpdateMotion(float progress);
    }
}
