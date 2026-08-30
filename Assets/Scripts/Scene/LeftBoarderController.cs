using UnityEngine;

public class LeftBoarderController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HealthController healthController = collision.GetComponent<HealthController>();
            SaveManager.SaveCurrentHealth(healthController.GetCurrentHealth());
            SceneController.LoadPreviousScene();
        }
    }
}
