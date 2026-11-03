using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextTweenSequence : MonoBehaviour
{
    [SerializeField] private float _stepDuration = 2f;
    [SerializeField] private float _transformationInterval = 0.5f;

    private Sequence _sequence;

    private void Start()
    {
        Text label = GetComponent<Text>();
        if (label == null)
        {
            return;
        }

        _sequence = DOTween.Sequence()
            .Append(label.DOText("Текст постепенно заменяется", _stepDuration))
            .AppendInterval(_transformationInterval)
            .AppendCallback(() => label.text = "Добавление: ")
            .Append(label.DOText("новых символов", _stepDuration).SetRelative())
            .AppendInterval(_transformationInterval)
            .AppendCallback(() => label.text = "Перебор: ")
            .Append(label.DOText("DOTween", _stepDuration, true, ScrambleMode.All))
            .SetLoops(-1, LoopType.Restart);
    }

    private void OnDestroy()
    {
        _sequence?.Kill();
    }
}