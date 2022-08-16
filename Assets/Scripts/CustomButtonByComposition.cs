using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Tween
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(RectTransform))]
    internal sealed class CustomButtonByComposition : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Button _button;
        [SerializeField] private RectTransform _rectTransform;

        [Header("Settings")]
        [SerializeField] private AnimationButtonType _animationButtonType = AnimationButtonType.ChangePosition;
        [SerializeField] private Ease _curveEase = Ease.Linear;
        [SerializeField] private float _duration = 0.6f;
        [SerializeField] private float _strength = 30f;
        [SerializeField] private LoopType _loopType = LoopType.Restart;
        [Min(-1)]
        [SerializeField] private int _loops = 0;

        private ButtonDOTweenAnimation _animation;

        private void OnValidate() => InitComponents();
        private void Awake() => InitComponents();

        private void Start() => _button.onClick.AddListener(OnButtonClick);
        private void OnDestroy() => _button.onClick.RemoveAllListeners();

        private void InitComponents()
        {
            _button ??= GetComponent<Button>();
            _rectTransform ??= GetComponent<RectTransform>();
            _animation = new(_rectTransform, _animationButtonType, _curveEase, _duration, _strength, _loopType, _loops);
        }

        private void OnButtonClick() =>
            _animation.ActivateAnimation();

        [ContextMenu(nameof(ButtonDOTweenAnimation.ActivateAnimation))]
        private void ActivateAnimation() =>
            _animation.ActivateAnimation();

        [ContextMenu(nameof(ButtonDOTweenAnimation.StopAnimation))]
        private void StopAnimation() =>
            _animation.StopAnimation();
    }
}
