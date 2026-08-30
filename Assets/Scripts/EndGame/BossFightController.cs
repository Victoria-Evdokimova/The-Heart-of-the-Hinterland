using UnityEngine;
using Cainos.CustomizablePixelCharacter;

public class BossFightController : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform player;

    [Header("Fireball")]
    [SerializeField] private GameObject fireball;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float spawnDelay = 2f;
    [SerializeField] private float fireballForce = 5f;

    [Header("Fight")]
    [SerializeField] private bool fightStarted;

    private PixelCharacterController controller;
    private float timer;

    private bool isCasting;
    private float castTimer;

    [SerializeField] private EndingController endingController;

    private void Awake()
    {
        controller = GetComponent<PixelCharacterController>();
    }

    private void Update()
    {
        if (player == null)
            return;

        if (controller != null)
        {
            controller.inputTarget = player.position + Vector3.up * 2;
            controller.inputLook = true;
        }

        if (isCasting)
        {
            castTimer -= Time.deltaTime;

            if (castTimer <= 0f)
            {
                controller.inputAttack = false;
                isCasting = false;
            }
        }

        if (!fightStarted)
            return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            timer = spawnDelay;

            controller.inputAttack = true;
            isCasting = true;
            castTimer = 0.3f;

            SpawnFireball();
        }
    }

    private void SpawnFireball()
    {
        GameObject ball = Instantiate(
            fireball,
            firePoint.position,
            Quaternion.identity
        );

        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            Vector2 targetPosition = player.position + Vector3.up;
            Vector2 direction = (targetPosition - (Vector2)firePoint.position).normalized;

            rb.AddForce(direction * fireballForce, ForceMode2D.Impulse);
        }
    }

    public void StartFight()
    {
        fightStarted = true;
        timer = 0f;
    }

    public void StopFight()
    {
        fightStarted = false;
    }

    private void OnDestroy()
    {
        if (endingController != null)
        {
            endingController.ShowEnding(EndingController.EndingType.BossDied);
        }
    }
}