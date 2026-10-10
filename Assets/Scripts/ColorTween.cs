using UnityEngine;
using DG.Tweening;

public class ColorTween : MonoBehaviour
{
    [SerializeField] private Color _targetColor = new Color(1f, 0.3f, 0.1f);
    [SerializeField] private float _duration = 2f;

    private Tween _colorTween;

    private void Start()
    {
        Renderer objectRenderer = GetComponent<Renderer>();
        if (objectRenderer == null)
        {
            return;
        }

        _colorTween = objectRenderer.material.DOColor(_targetColor, _duration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        _colorTween?.Kill();
    }
}