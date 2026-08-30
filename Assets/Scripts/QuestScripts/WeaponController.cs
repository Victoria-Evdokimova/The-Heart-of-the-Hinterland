using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private GameObject axe;
    [SerializeField] private GameObject vial;
    [SerializeField] private GameObject map;
    [SerializeField] private GameObject sword;

    public void UpdateQuestItem
    (
        int questId,
        QuestState state
    )
    {
        axe.SetActive(false);
        vial.SetActive(false);
        map.SetActive(false);
        sword.SetActive(false);

        if (state != QuestState.InProgress)
            return;

        switch (questId)
        {
            case 0:
                axe.SetActive(true);
                break;

            case 1:
                vial.SetActive(true);
                break;

            case 2:
                map.SetActive(true);
                break;

            case 3:
                sword.SetActive(true);
                break;
        }
    }
}