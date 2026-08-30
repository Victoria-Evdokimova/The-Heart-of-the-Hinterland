using Cainos.PixelArtMonster_Dungeon;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndingDialogueController : MonoBehaviour
{
    [Header("Root")]
    [SerializeField] private GameObject dialoguePanel;

    [Header("UI To Hide")]
    [SerializeField] private GameObject[] uiToHide;


    [Header("Dialogue")]
    [SerializeField] private EndingDialogueNode startNode;

    [Header("UI")]
    [SerializeField] private TMP_Text npcText;

    [SerializeField] private Button choiceButton1;
    [SerializeField] private Button choiceButton2;

    private EndingDialogueNode currentNode;
    private EndingController endingController;

    [SerializeField] private GameObject william;

    private int goodAnswers;
    private int badAnswers;

    private string currentLanguage;
    [SerializeField] private TMP_Text playerName;
    [SerializeField] private TMP_Text bossName;

    private void Awake()
    {
        endingController = gameObject.GetComponent<EndingController>();
    }

    private void Start()
    {
        currentLanguage = SaveManager.LoadLanguage();

        if (currentLanguage == "RU")
        {
            playerName.text = "Джэк Вуд";
            bossName.text = "Уильям Джонсон";
        }
        else if (currentLanguage == "EN")
        {
            playerName.text = "Jack Wood";
            bossName.text = "William Johnson";
        }
    }

    private void ShowNode(EndingDialogueNode node)
    {
        string language = SaveManager.LoadLanguage();

        npcText.text = language == "RU"
            ? node.npcTextRU
            : node.npcTextEN;

        choiceButton1.gameObject.SetActive(false);
        choiceButton2.gameObject.SetActive(false);

        if (node.choices.Length > 0)
        {
            choiceButton1.gameObject.SetActive(true);

            choiceButton1.GetComponentInChildren<TMP_Text>().text =
                language == "RU"
                ? node.choices[0].playerTextRU
                : node.choices[0].playerTextEN;

            choiceButton1.onClick.RemoveAllListeners();
            choiceButton1.onClick.AddListener(() => SelectChoice(0));
        }

        if (node.choices.Length > 1)
        {
            choiceButton2.gameObject.SetActive(true);

            choiceButton2.GetComponentInChildren<TMP_Text>().text =
                language == "RU"
                ? node.choices[1].playerTextRU
                : node.choices[1].playerTextEN;

            choiceButton2.onClick.RemoveAllListeners();
            choiceButton2.onClick.AddListener(() => SelectChoice(1));
        }
    }

    public void SelectChoice(int choiceIndex)
    {
        EndingDialogueChoice choice = currentNode.choices[choiceIndex];

        if (choice.isPositive)
        {
            goodAnswers++;
        }
        else
        {
            badAnswers++;
        }

        if (goodAnswers > 3)
        {
            GoodEnding();
            return;
        }

        if (badAnswers > 3)
        {
            BadEnding();
            return;
        }

        currentNode = choice.nextNode;

        if (currentNode != null)
        {
            ShowNode(currentNode);
        }
    }

    private void GoodEnding()
    {
        Debug.Log("Good Ending");
        EndDialogue();

        endingController.ShowEnding(EndingController.EndingType.PeacefulEnding);
        // Тут загрузка хорошей концовки
        // SceneManager.LoadScene("GoodEnding");
    }

    private void BadEnding()
    {
        EndDialogue();

        BatEndingAttack[] bats = FindObjectsByType<BatEndingAttack>(
            FindObjectsInactive.Include,
            FindObjectsSortMode.None);

        foreach (BatEndingAttack bat in bats)
        {
            MonsterMovement movement = bat.GetComponent<MonsterMovement>();

            if (movement != null)
                movement.enabled = false;

            MonsterInputMouseAndKeyboard input = bat.GetComponent<MonsterInputMouseAndKeyboard>();

            if (input != null)
                input.enabled = false;

            bat.enabled = true;
        }

        BossFightController bossfightcontroller = william.GetComponent<BossFightController>();
        bossfightcontroller.StartFight();

        Debug.Log("Bad Ending");
    }

    public void StartDialogue()
    {
        foreach (GameObject ui in uiToHide)
        {
            if (ui != null)
                ui.SetActive(false);
        }

        dialoguePanel.SetActive(true);
        Time.timeScale = 0f;
        currentNode = startNode;
        ShowNode(currentNode);

    }

    private void EndDialogue()
    {
        Time.timeScale = 1f;
        dialoguePanel.SetActive(false);

        foreach (GameObject ui in uiToHide)
        {
            if (ui != null)
                ui.SetActive(true);
        }
    }
}