using RL.Animation.Base;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace RL.Animation.Misc
{
    [RequireComponent(typeof(BaseAnimation))]
    public class TogglePanel : MonoBehaviour
    {
        public PanelState initialState = PanelState.Default;
        public float autoCloseTimeout = 0f;
        private BaseAnimation anim;
        private bool _currentState = true;
        private UnityEvent onShow = new UnityEvent();
        private UnityEvent onHide = new UnityEvent();
        public bool currentState
        {
            get
            {
                if (initialized == false)
                {
                    return initialState == PanelState.Close ? false : true;
                }
                return _currentState;
            }
            private set
            {
                _currentState = value;
            }
        }
        public float toggleDuration
        {
            get
            {
                return anim.TotalDuration;
            }
        }
        private bool initialized = false;

        private void Awake()
        {
            if (!initialized)
                Initialize();
        }

        public void Show()
        {
            Toggle(true);
        }

        public void Hide(bool force = false)
        {
            Toggle(false, false, force);
        }

        public void Toggle(bool state, bool forceSuddenly = false, bool force = false)
        {
            var animation = GetAnimation();
            if (state == currentState && !force)
                return;
            currentState = state;
            if (state)
            {
                gameObject.SetActive(true);
            }
            var suddenly = forceSuddenly || !gameObject.activeInHierarchy;
            animation.Play(state ? AnimationDirection.Forward :
                AnimationDirection.Backward, suddenly,
                 () => {
                     if (state)
                     {
                         onShow.Invoke();
                         if (autoCloseTimeout > 0)
                             StartCoroutine(AutoClose());
                     }
                     else
                     {
                         onHide.Invoke();
                         gameObject.SetActive(false);
                     }
                 });
        }

        public void ManualInitialize()
        {
            if (!initialized)
                Initialize();
        }

        public void AddShowListener(UnityAction listener)
        {
            onShow.AddListener(listener);
        }

        public void RemoveShowListener(UnityAction listener)
        {
            onShow.RemoveListener(listener);
        }

        public void AddHideListener(UnityAction listener)
        {
            onHide.AddListener(listener);
        }

        public void RemoveHideListener(UnityAction listener)
        {
            onHide.RemoveListener(listener);
        }

        private void Initialize()
        {
            anim = GetComponent<BaseAnimation>();
            switch (initialState)
            {
                case PanelState.Open:
                    currentState = true;
                    anim.Play(AnimationDirection.Forward, true);
                    break;
                case PanelState.Close:
                    currentState = false;
                    anim.Play(AnimationDirection.Backward, true);
                    gameObject.SetActive(false);
                    break;
                default:
                    currentState = gameObject.activeSelf;
                    break;
            }
            initialized = true;
        }

        private BaseAnimation GetAnimation()
        {
            if (!initialized)
            {
                Initialize();
                return anim;
            }
            else
            {
                return anim;
            }
        }

        private IEnumerator AutoClose()
        {
            yield return new WaitForSeconds(autoCloseTimeout);
            Toggle(false);
        }
        public enum PanelState
        {
            Default = 0,
            Open = 1,
            Close = 2
        }
    }
}
