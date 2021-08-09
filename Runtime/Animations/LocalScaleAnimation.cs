using RL.Animation.Base;
using UnityEngine;

namespace RL.Animation.Animations
{
    public class LocalScaleAnimation : BaseAnimation
    {
        public Vector3 From;
        public Vector3 To;

        private Vector3 current;

        protected override void Initialize()
        {
        }

        protected override void Animate(float t)
        {

            current = Vector3.Lerp(From, To, t);
            transform.localScale = current;
        }
    }
}
