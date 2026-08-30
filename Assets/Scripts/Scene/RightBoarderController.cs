using UnityEngine;

public class RightBoarderController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HealthController healthController = collision.GetComponent<HealthController>();
            SaveManager.SaveCurrentHealth(healthController.GetCurrentHealth());
            SceneController.LoadNextScene();
        }
    }
}
