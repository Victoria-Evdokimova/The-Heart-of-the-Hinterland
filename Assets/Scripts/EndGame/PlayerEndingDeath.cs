using UnityEngine;

public class PlayerEndingDeath : MonoBehaviour
{
    [SerializeField] private EndingController endingController;

    private void OnDestroy()
    {
        if (endingController != null)
        {
            endingController.ShowEnding(EndingController.EndingType.PlayerDied);
        }
    }
}
