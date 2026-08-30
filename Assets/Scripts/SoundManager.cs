using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource monsterDeathSound;

    private void Awake()
    {
        Instance = this;
    }

    public static void PlayMonsterDeathSound()
    {
        if (Instance != null)
        {
            Instance.monsterDeathSound.Play();
        }
    }
}
