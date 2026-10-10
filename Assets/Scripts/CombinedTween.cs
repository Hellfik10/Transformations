using UnityEngine;
using DG.Tweening;

public class CombinedTween : MonoBehaviour
{
    [SerializeField] private Vector3 _moveOffset = new Vector3(0f, 0f, 2f);
    [SerializeField] private Vector3 _rotationOffset = new Vector3(0f, 360f, 0f);
    [SerializeField] private Vector3 _targetScale = new Vector3(1.5f, 1.5f, 1.5f);
    [SerializeField] private float _duration = 2f;

    private Sequence _sequence;

    private void Start()
    {
        _sequence = DOTween.Sequence()
            .Join(transform.DOMove(transform.position + _moveOffset, _duration))
            .Join(transform.DORotate(
                transform.eulerAngles + _rotationOffset,
                _duration,
                RotateMode.FastBeyond360))
            .Join(transform.DOScale(_targetScale, _duration))
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        _sequence?.Kill();
    }
}