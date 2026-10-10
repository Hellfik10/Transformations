using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextTweenSequence : MonoBehaviour
{
    [SerializeField] private float _stepDuration = 2f;

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
            .AppendInterval(0.5f)
            .AppendCallback(() => label.text = "Добавление: ")
            .Append(label.DOText("новых символов", _stepDuration))
            .AppendInterval(0.5f)
            .AppendCallback(() => label.text = "Перебор: ")
            .Append(label.DOText("DOTween", _stepDuration, true, ScrambleMode.All))
            .SetLoops(-1, LoopType.Restart);
    }

    private void OnDestroy()
    {
        _sequence?.Kill();
    }
}