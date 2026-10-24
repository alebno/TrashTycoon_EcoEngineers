using UnityEngine;
using TMPro;

[System.Serializable]
public struct DialogueLine
{
    public string speakerName;
    public Color nameColor;
    [TextArea(2, 5)] public string text;
}

public class NPCDialogueAvanzado : MonoBehaviour
{
    [Header("Secuencia de Conversacion")]
    [SerializeField] private DialogueLine[] conversation;

    [Header("Referencias de Interfaz (UI)")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text contentText;
    [SerializeField] private GameObject interactionPrompt;

    private bool isPlayerInRange = false;
    private bool isDialogueActive = false;
    private int currentLineIndex = 0;

    private void Start()
    {
        SafeSetActive(dialoguePanel, false);
        SafeSetActive(interactionPrompt, false);
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isDialogueActive) StartDialogue();
            else NextDialogueLine();
        }
    }

    private void StartDialogue()
    {
        if (conversation == null || conversation.Length == 0) return;
        isDialogueActive = true;
        currentLineIndex = 0;
        SafeSetActive(dialoguePanel, true);
        SafeSetActive(interactionPrompt, false);
        DisplayCurrentLine();
    }

    private void NextDialogueLine()
    {
        currentLineIndex++;
        if (currentLineIndex < conversation.Length)
        {
            DisplayCurrentLine();
        }
        else
        {
            EndDialogue();
        }
    }

    private void DisplayCurrentLine()
    {
        if (nameText != null)
        {
            nameText.text = conversation[currentLineIndex].speakerName;
            if (conversation[currentLineIndex].nameColor.a > 0f)
            {
                nameText.color = conversation[currentLineIndex].nameColor;
            }
        }
        if (contentText != null)
        {
            contentText.text = conversation[currentLineIndex].text;
        }
    }

    private void EndDialogue()
    {
        isDialogueActive = false;
        SafeSetActive(dialoguePanel, false);
        if (isPlayerInRange)
        {
            SafeSetActive(interactionPrompt, true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            if (!isDialogueActive)
            {
                SafeSetActive(interactionPrompt, true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            EndDialogue();
            SafeSetActive(interactionPrompt, false);
        }
    }

    
    private void SafeSetActive(GameObject obj, bool state)
    {
        try
        {
            if (obj != null && obj.gameObject != null)
            {
                obj.SetActive(state);
            }
        }
        catch
        {
   
        }
    }
}