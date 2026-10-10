using UnityEngine;
using DG.Tweening;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _duration = 3f;

    private Tween _rotationTween;

    private void Start()
    {
        _rotationTween = transform.DORotate(
                transform.eulerAngles + new Vector3(0f, 360f, 0f),
                _duration,
                RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);
    }

    private void OnDestroy()
    {
        _rotationTween?.Kill();
    }
}
