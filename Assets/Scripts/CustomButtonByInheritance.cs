using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Tween
{
    [RequireComponent(typeof(RectTransform))]
    public sealed class CustomButtonByInheritance : Button
    {
        public static string AnimationTypeName => nameof(_animationButtonType);
        public static string CurveEaseName => nameof(_curveEase);
        public static string DurationName => nameof(_duration);
        public static string StrengthName => nameof(_strength);
        public static string LoopTypeName => nameof(_loopType);
        public static string LoopsName => nameof(_loops);


        [SerializeField] private RectTransform _rectTransform;

        [SerializeField] private AnimationButtonType _animationButtonType = AnimationButtonType.ChangePosition;
        [SerializeField] private Ease _curveEase = Ease.Linear;
        [SerializeField] private float _duration = 0.6f;
        [SerializeField] private float _strength = 30f;
        [SerializeField] private LoopType _loopType = LoopType.Restart;
        [Min(-1)]
        [SerializeField] private int _loops = 0;

        private ButtonDOTweenAnimation _animation;


        protected override void Awake()
        {
            base.Awake();
            InitRectTransform();
        }

        protected override void OnValidate()
        {
            base.OnValidate();
            InitRectTransform();
        }

        private void InitRectTransform()
        {
            _rectTransform ??= GetComponent<RectTransform>();
            _animation = new(_rectTransform, _animationButtonType, _curveEase, _duration, _strength, _loopType, _loops);
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            _animation.ActivateAnimation();
        }

        [ContextMenu(nameof(ButtonDOTweenAnimation.ActivateAnimation))]
        private void ActivateAnimation() =>
            _animation.ActivateAnimation();

        [ContextMenu(nameof(ButtonDOTweenAnimation.StopAnimation))]
        private void StopAnimation() =>
            _animation.StopAnimation();
    }
}
