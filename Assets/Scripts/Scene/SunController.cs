using UnityEngine;

public class SunController : MonoBehaviour
{
    [SerializeField] private Transform followingTarget;
    [SerializeField] private float offsetX = 0f;
    [SerializeField] private float worldY = 20f;
    private float worldZ = 0f;


    private void Start()
    {
        if (followingTarget == null)
        {
            followingTarget = Camera.main.transform;
        }
        UpdatePosition();
    }

    private void LateUpdate()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        transform.position = new Vector3(followingTarget.position.x + offsetX, worldY, worldZ);
    }
}
