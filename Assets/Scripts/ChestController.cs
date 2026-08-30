using UnityEngine;
using UnityEngine.InputSystem;

public class ChestController : MonoBehaviour
{
    [SerializeField] private ParticleSystem openEffect;
    [SerializeField] private AudioClip chestSound;

    private Animator animator;
    private AudioSource audioSource;

    private bool playerInside;
    private bool isOpen;
    private bool rewardGiven;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!playerInside)
            return;

        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            isOpen = !isOpen;
            animator.SetBool("IsOpen", isOpen);

            if (audioSource != null && chestSound != null)
            {
                audioSource.PlayOneShot(chestSound);
            }

            if (!rewardGiven)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");

                if (player != null)
                {
                    HealthController health = player.GetComponent<HealthController>();

                    if (health != null)
                    {
                        health.RestoreHealth();
                    }
                }

                if (openEffect != null)
                {
                    openEffect.Play();
                }

                rewardGiven = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
}