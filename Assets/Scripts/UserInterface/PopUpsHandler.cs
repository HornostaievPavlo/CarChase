using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUpsHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject startMenu;

    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private GameObject gameOverMenu;

    private TMP_Text countdownText;
    private const float COUNTDOWN_DURATION = 3f;

    private void Start()
    {
        SetTimeScale(0f);

        EventsHandler.LevelFailed.AddListener(WaitForGameOverMenu);

        countdownText = startMenu.GetComponentInChildren<TMP_Text>();
        StartCoroutine(StartCountdown());
    }

    private void SetTimeScale(float newTimeScale) => Time.timeScale = newTimeScale;

    private IEnumerator StartCountdown()
    {
        float currentTime = COUNTDOWN_DURATION;

        while (currentTime > 0)
        {
            countdownText.text = Mathf.CeilToInt(currentTime).ToString();

            yield return null;

            currentTime -= Time.unscaledDeltaTime;
        }

        countdownText.text = "START";

        yield return new WaitForSecondsRealtime(1f);

        startMenu.SetActive(false);

        SetTimeScale(1f);
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

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame() => Application.Quit();
}
