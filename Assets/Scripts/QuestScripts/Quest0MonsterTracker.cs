using UnityEngine;

public class Quest0MonsterTracker : MonoBehaviour
{
    [SerializeField] private QuestSystem questSystem;

    private int killedMonsters;

    public void RegisterKill()
    {
        if (questSystem.CurrentQuestId != 0)
            return;

        killedMonsters++;

        if (killedMonsters >= 6)
        {
            questSystem.CompleteQuestObjective();
        }
    }
}