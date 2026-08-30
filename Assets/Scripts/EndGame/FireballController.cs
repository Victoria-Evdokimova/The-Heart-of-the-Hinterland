using UnityEngine;

public class FireballController : MonoBehaviour
{
    [SerializeField] private float lifeTime = 1.0f;

    private void Update()
    {
        if (lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
