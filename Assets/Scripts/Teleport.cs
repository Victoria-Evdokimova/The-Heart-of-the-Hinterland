using UnityEngine;

public class Teleport: MonoBehaviour
{
    [SerializeField] private Transform exitPoint; // Ссылка на TeleportExit

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, что вошел именно игрок (нужно добавить тег Player игроку)
        if (other.CompareTag("Player"))
        {
            // Перемещаем игрока
            other.transform.position = exitPoint.position;
        }
    }
}


