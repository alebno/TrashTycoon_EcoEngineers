using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Paneles de Interfaz")]
    [SerializeField] private GameObject creditsPanel;

    // Carga la escena del juego ("GameScene")
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Muestra el panel con la informacion pedagogica y creditos
    public void OpenCredits()
    {
        if (creditsPanel != null)
        {
            creditsPanel.SetActive(true);
        }
    }

    // Oculta el panel de creditos
    public void CloseCredits()
    {
        if (creditsPanel != null)
        {
            creditsPanel.SetActive(false);
        }
    }

    // Cierra la aplicacion (funciona en el juego compilado y en el editor)
    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}