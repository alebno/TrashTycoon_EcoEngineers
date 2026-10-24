using UnityEngine;
using TMPro;

public class GameHUDManager : MonoBehaviour
{
    public static GameHUDManager Instance { get; private set; }

    [Header("Textos del HUD")]
    [SerializeField] private TMP_Text counterText;
    [SerializeField] private GameObject missionCompletePanel;

    [Header("Meta")]
    [SerializeField] private int totalRequired = 5;
    private int currentCollected = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        UpdateHUD();
        if (missionCompletePanel != null) missionCompletePanel.SetActive(false);
    }

    public void AddCollectible(int amount)
    {
        currentCollected += amount;
        UpdateHUD();

        if (currentCollected >= totalRequired)
        {
            if (missionCompletePanel != null) missionCompletePanel.SetActive(true);
        }
    }

    private void UpdateHUD()
    {
        if (counterText != null)
        {
            counterText.text = $"Residuos: {currentCollected} / {totalRequired}";
        }
    }
}