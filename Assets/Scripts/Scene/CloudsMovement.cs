using UnityEngine;

public class CloudsMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float width = 15f;

    private void Update()
    {
        transform.localPosition += Vector3.left * speed * Time.deltaTime;

        if (transform.localPosition.x <= -width)
        {
            transform.localPosition += Vector3.right * width*2;
        }
    }
}