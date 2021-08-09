using UnityEngine;
using RL.Animation.Base;

namespace RL.Animation.Animations
{
    public class EmissionColorAnimation : BaseAnimation
    {
        public Material material;
        [ColorUsage(true, true)]
        public Color From;
        [ColorUsage(true, true)]
        public Color To;

        protected override void Initialize()
        {
        }

        protected override void Animate(float t)
        {
            material.SetColor("_EmissionColor",
                Color.Lerp(From, To, t));
        }
    }
}
