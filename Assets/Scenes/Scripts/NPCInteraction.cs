using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [Header("NPC Data")]
    public string npcID;

    [TextArea]
    public string dialogueText;

    public DialogueChoice[] choices;

    private bool playerInRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            DialogueUI.Instance.ShowInteractPrompt(this);

        }
        else
        {
            DialogueUI.Instance.HidePrompt();
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            DialogueUI.Instance.OpenDialogue(this);
        }
    }
}
