using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private TMP_Text scoreText;

    private int currentScore;

    private const int COIN_VALUE = 10;

    private void Start()
    {
        currentScore = 0;

        scoreText = GetComponentInChildren<TMP_Text>();

        scoreText.text = currentScore.ToString();

        EventsHandler.CoinCollected.AddListener(IncreaseScore);
    }

    private void IncreaseScore()
    {
        currentScore += COIN_VALUE;

        scoreText.text = currentScore.ToString();
    }
}
