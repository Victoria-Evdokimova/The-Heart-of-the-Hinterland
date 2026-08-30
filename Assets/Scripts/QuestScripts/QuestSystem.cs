using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    [SerializeField] private WeaponController weaponController;

    public int CurrentQuestId { get; private set; }

    public QuestState CurrentState { get; private set; }
        = QuestState.NotStarted;

    private void Start()
    {
        CurrentQuestId =
            SaveManager.LoadCurrentQuest();

        CurrentState =
            SaveManager.LoadQuestState();

        UpdateWeapon();
    }

    public void StartQuest()
    {
        CurrentState = QuestState.InProgress;

        SaveManager.SaveQuestState(CurrentState);

        UpdateWeapon();
    }

    public void CompleteQuestObjective()
    {
        CurrentState = QuestState.ReadyToTurnIn;

        SaveManager.SaveQuestState(CurrentState);

        UpdateWeapon();
    }

    public void TurnInQuest()
    {
        CurrentQuestId++;

        CurrentState = QuestState.NotStarted;

        SaveManager.SaveCurrentQuest(
            CurrentQuestId
        );

        SaveManager.SaveQuestState(
            CurrentState
        );

        UpdateWeapon();
    }

    private void UpdateWeapon()
    {
        weaponController.UpdateQuestItem
        (
            CurrentQuestId,
            CurrentState
        );
    }
}