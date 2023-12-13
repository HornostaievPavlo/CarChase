using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    private TMP_Text bestScoreText;

    [SerializeField]
    private TMP_Text menuScoreText;

    [SerializeField]
    private TMP_Text onScreenScoreText;

    private int currentScore;
    private int bestScore;

    private const int COIN_VALUE = 10;

    private void Start()
    {
        currentScore = 0;

        bestScoreText.text = bestScore.ToString();

        EventsHandler.CoinCollected.AddListener(IncreaseScore);
        EventsHandler.LevelFailed.AddListener(ShowScore);

        DontDestroyOnLoad(this.gameObject);
    }

    private void ShowScore()
    {
        if (currentScore > bestScore)
        {
            bestScore = currentScore;

            bestScoreText.text = bestScore.ToString();
        }

        menuScoreText.text = currentScore.ToString();
    }

    private void IncreaseScore()
    {
        currentScore += COIN_VALUE;

        onScreenScoreText.text = currentScore.ToString();
    }
}
