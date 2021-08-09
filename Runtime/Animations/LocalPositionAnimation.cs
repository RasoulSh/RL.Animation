using RL.Animation.Base;
using UnityEngine;

namespace RL.Animation.Animations
{
    public class LocalPositionAnimation : BaseAnimation
    {
        public Vector3 From;
        public Vector3 To;

        private Vector3 currentLocalPos;

        protected override void Initialize()
        {
        }

        protected override void Animate(float t)
        {

            currentLocalPos = Vector3.Lerp(From, To, t);
            transform.localPosition = currentLocalPos;
        }
    }
}
