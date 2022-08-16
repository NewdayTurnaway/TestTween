using DG.Tweening;
using UnityEngine;

namespace Tween
{
    internal sealed class ButtonDOTweenAnimation
    {
        private readonly RectTransform _rectTransform;
        private readonly AnimationButtonType _animationButtonType;
        private readonly Ease _curveEase;
        private readonly float _duration;
        private readonly float _strength;
        private readonly LoopType _loopType;
        private readonly int _loops;

        private Tweener _tweener;

        public ButtonDOTweenAnimation(RectTransform rectTransform, AnimationButtonType animationButtonType, 
            Ease curveEase, float duration, float strength, LoopType loopType, int loops)
        {
            _rectTransform = rectTransform;
            _animationButtonType = animationButtonType;
            _curveEase = curveEase;
            _duration = duration;
            _strength = strength;
            _loopType = loopType;
            _loops = loops;
        }

        public void ActivateAnimation()
        {
            StopAnimation();

            _tweener = _animationButtonType switch
            {
                AnimationButtonType.ChangeRotation => _rectTransform.DOShakeRotation(_duration, Vector3.forward * _strength),
                AnimationButtonType.ChangePosition => _rectTransform.DOShakeAnchorPos(_duration, Vector2.one * _strength),
                _ => default,
            };

            _tweener.SetEase(_curveEase).SetLoops(_loops, _loopType);
        }

        public void StopAnimation()
        {
            _rectTransform.DOKill(_rectTransform);
        }
    } 
}
