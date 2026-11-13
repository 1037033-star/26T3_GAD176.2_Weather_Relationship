using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Instance;

    [Header("Panels")]
    public GameObject interactPrompt;
    public GameObject dialoguePanel;

    [Header("UI")]
    public TMP_Text dialogueText;
    public Button[] choiceButtons;

    private NPCInteraction currentNPC;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowInteractPrompt(NPCInteraction npc)
    {
        interactPrompt.SetActive(true);
    }

    public void HidePrompt()
    {
        interactPrompt.SetActive(false);
    }

    public void OpenDialogue(NPCInteraction npc)
    {
        currentNPC = npc;

        dialoguePanel.SetActive(true);
        dialogueText.text = npc.dialogueText;

        for (int i = 0; i < choiceButtons.Length; i++)
        {
            if (i < npc.choices.Length)
            {
                choiceButtons[i].gameObject.SetActive(true);

                int index = i;

                choiceButtons[i].GetComponentInChildren<TMP_Text>().text =
                    npc.choices[i].buttonText;

                choiceButtons[i].onClick.RemoveAllListeners();

                choiceButtons[i].onClick.AddListener(() =>
                {
                    SelectChoice(index);
                });
            }
            else
            {
                choiceButtons[i].gameObject.SetActive(false);
            }
        }
    }

    void SelectChoice(int index)
    {
        DialogueChoice choice = currentNPC.choices[index];

        RelationshipManager.Instance.ChangeRelationship(
            currentNPC.npcID,
            choice.relationshipChange);

        dialogueText.text = choice.response;

        Invoke(nameof(CloseDialogue), 2f);
    }

    void CloseDialogue()
    {
        dialoguePanel.SetActive(false);
    }
}
