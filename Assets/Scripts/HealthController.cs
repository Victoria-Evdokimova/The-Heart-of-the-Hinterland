using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;

    [SerializeField] private bool isPlayer;

    [SerializeField] private EndingController endingController;

    private int currentHealth;

    private void Awake()
    {
        if (isPlayer)
        {
            currentHealth = SaveManager.LoadCurrentHealth();
        }
        else
        {
            RestoreHealth();
        }
    }

    public void TakeDamage()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    public void RestoreHealth()
    {
        currentHealth = maxHealth;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    private void Die()
    {
        if (CompareTag("Player"))
        {
            if (SceneController.ShowCurrentScene() != 3)
            {
                SceneController.RestartScene();
            }
            else
            {
                endingController.ShowEnding(EndingController.EndingType.PlayerDied);
            }
        }
        else if (CompareTag("Monster"))
        {
            Quest0MonsterTracker tracker = FindFirstObjectByType<Quest0MonsterTracker>();
            if (tracker != null)
            {
                tracker.RegisterKill();
            }
            SoundManager.PlayMonsterDeathSound();
            Destroy(gameObject);
        }
    }
}