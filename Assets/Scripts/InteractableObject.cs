using UnityEngine;
using TMPro;

public class InteractableObject : MonoBehaviour
{
    [Header("Aviso Flotante")]
    [SerializeField] private GameObject promptFloatingText; // Tecla E

    [Header("Contenido Educativo")]
    [SerializeField] private GameObject infoDisplayPanel;
    [SerializeField] private TMP_Text infoTextComponent;
    [TextArea(3, 6)]
    [SerializeField] private string educationalContent = "Dato ambiental...";

    private bool isPlayerNearby = false;
    private bool isPanelOpen = false;

    private void Start()
    {
        if (promptFloatingText != null) promptFloatingText.SetActive(false);
        if (infoDisplayPanel != null) infoDisplayPanel.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            ToggleInteraction();
        }
    }

    private void ToggleInteraction()
    {
        isPanelOpen = !isPanelOpen;
        if (infoDisplayPanel != null) infoDisplayPanel.SetActive(isPanelOpen);
        if (infoTextComponent != null) infoTextComponent.text = educationalContent;
        if (promptFloatingText != null) promptFloatingText.SetActive(!isPanelOpen);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (promptFloatingText != null && !isPanelOpen)
                promptFloatingText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            isPanelOpen = false;
            if (promptFloatingText != null) promptFloatingText.SetActive(false);
            if (infoDisplayPanel != null) infoDisplayPanel.SetActive(false);
        }
    }
}