using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject health1;
    [SerializeField] private GameObject health2;
    [SerializeField] private GameObject health3;
    [SerializeField] private GameObject health4;
    [SerializeField] private GameObject health5;

    [SerializeField] private HealthController healthController;

    private void Update()
    {
        health1.SetActive(false);
        health2.SetActive(false);
        health3.SetActive(false);
        health4.SetActive(false);
        health5.SetActive(false);

        int currentHealth = healthController.GetCurrentHealth();

        if (currentHealth >= 1)
        {
            health1.SetActive(true);
            if (currentHealth >= 2)
            {
                health2.SetActive(true);
                if (currentHealth >= 3)
                {
                    health3.SetActive(true);
                    if (currentHealth >= 4)
                    {
                        health4.SetActive(true);
                        if (currentHealth >= 5)
                        {
                            health5.SetActive(true);
                        }
                    }
                }
            }
        }
    }
}
