using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawns;

    private void Start()
    {
        int spawnId;

        if (SaveManager.LoadCurrentScene() == 1)
            spawnId = SaveManager.LoadCurrentQuest();
        else
            spawnId = SaveManager.LoadCheckpoint();

        if (spawnId >= 0 && spawnId < spawns.Length)
        {
            transform.position = spawns[spawnId].position;
        }
    }
}