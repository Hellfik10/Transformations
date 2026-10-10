using UnityEngine;
using DG.Tweening;

public class Rescaler : MonoBehaviour
{
    [SerializeField] private Vector3 _targetScale = new Vector3(1.6f, 1.6f, 1.6f);
    [SerializeField] private float _duration = 1.5f;

    private Tween _scaleTween;

    private void Start()
    {
        _scaleTween = transform.DOScale(_targetScale, _duration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        _scaleTween?.Kill();
    }
}
