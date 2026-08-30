using UnityEngine;

public class QuestObjectController : MonoBehaviour
{
    [SerializeField] private GameObject monsters;

    [SerializeField] private GameObject quest0On;

    [SerializeField] private GameObject quest2On;
    [SerializeField] private GameObject quest2Off;

    private int lastQuestId = -1;

    private void Update()
    {
        int questId = SaveManager.LoadCurrentQuest();

        if (lastQuestId == questId)
            return;

        lastQuestId = questId;

        monsters.SetActive(questId == 0);

        if (questId > 0)
        {
            quest0On.SetActive(true);
        }

        if (questId > 2)
        {
            quest2On.SetActive(true);
            quest2Off.SetActive(false);
        }
    }
}