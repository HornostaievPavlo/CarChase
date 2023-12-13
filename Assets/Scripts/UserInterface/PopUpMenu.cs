using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUpMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private GameObject gameOverMenu;

    private void Start()
    {
        SetTimeScale(1.0f);

        EventsHandler.LevelFailed.AddListener(WaitForGameOverMenu);
    }

    private void SetTimeScale(float newTimeScale) => Time.timeScale = newTimeScale;

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        SetTimeScale(0.0f);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        SetTimeScale(1.0f);
    }

    private void WaitForGameOverMenu()
    {
        StartCoroutine(ShowGameOverMenu());
    }

    private IEnumerator ShowGameOverMenu()
    {
        yield return new WaitForSeconds(2f);
        gameOverMenu.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame() => Application.Quit();
}
