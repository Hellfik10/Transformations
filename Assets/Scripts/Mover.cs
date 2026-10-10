using UnityEngine;
using DG.Tweening;

public class Mover : MonoBehaviour
{
    [SerializeField] private Vector3 _moveOffset = new Vector3(0f, 0f, 2f);
    [SerializeField] private float _duration = 2f;

    private Tween _moveTween;

    private void Start()
    {
        _moveTween = transform.DOMove(transform.position + _moveOffset, _duration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        _moveTween?.Kill();
    }
}
