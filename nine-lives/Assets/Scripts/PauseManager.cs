using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;       
using UnityEngine.Rendering.Universal;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pausePanel; 
    [SerializeField] string mainMenuScene = "Main Menu";

    [SerializeField] private Volume postVolume;
    private ChromaticAberration ca;

    bool paused;

    void Awake()
    {
        if (postVolume) postVolume.profile.TryGet(out ca); // cache the CA override if present
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }

    public void TogglePause()
    {
        paused = !paused;
        Time.timeScale = paused ? 0f : 1f;
        if (pausePanel) pausePanel.SetActive(paused);
        Cursor.visible = paused;
        Cursor.lockState = paused ? CursorLockMode.None : CursorLockMode.Locked;
        if (ca != null) ca.active = !paused;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(mainMenuScene);

    }
}
