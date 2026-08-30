using UnityEngine;
using UnityEngine.UI;

public class SpeakerImageLoader : MonoBehaviour
{
    [SerializeField] private QuestSystem questSystem;
    [SerializeField] private Image portraitImage;
    [SerializeField] private Sprite[] questPortraits;


    private void Update()
    {
        int questId = questSystem.CurrentQuestId;

        if (questId >= 0 && questId < questPortraits.Length)
        {
            portraitImage.sprite = questPortraits[questId];
        }
    }
}
