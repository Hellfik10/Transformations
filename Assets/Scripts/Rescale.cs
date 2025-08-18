using UnityEngine;

public class Rescale : MonoBehaviour
{
    [SerializeField] private float _rescalingSpeed;

    void FixedUpdate()
    {
        transform.localScale = transform.localScale + new Vector3(_rescalingSpeed * Time.deltaTime, _rescalingSpeed * Time.deltaTime, _rescalingSpeed * Time.deltaTime);
    }
}
