using UnityEngine;

public class Rescaler : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.localScale += Vector3.one * (_speed * Time.deltaTime);
    }
}
