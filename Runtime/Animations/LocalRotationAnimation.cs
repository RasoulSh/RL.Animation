using UnityEngine;
using RL.Animation.Base;

namespace RL.Animation.Animations
{
    public class LocalRotationAnimation : BaseAnimation
    {
        public Vector3 From;
        public Vector3 To;

        private Vector3 currentLocalRot;

        protected override void Initialize()
        {
        }

        protected override void Animate(float t)
        {
            currentLocalRot = Vector3.Lerp(From, To, t);
            transform.localEulerAngles = currentLocalRot;
        }
    }
}
