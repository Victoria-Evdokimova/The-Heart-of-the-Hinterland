using UnityEngine;

public class WindmillRotate : MonoBehaviour
{
    [SerializeField] private float speed = 120f;
    private void Update()
    {
        transform.Rotate(0f, 0f, speed * Time.deltaTime);
    }
}
