using TMPro;
using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private int spacePressIncrement = 1;
    [SerializeField] private KeyCode incrementKey = KeyCode.Space;

    private int currentScore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        UpdateScoreDisplay();
    }

    private void Update()
    {
        if (Input.GetKeyDown(incrementKey))
        {
            /*
            AddScore(spacePressIncrement);
            StartCoroutine(FlashScoreText());
            */
        }
    }

    private IEnumerator FlashScoreText()
    {
        
        scoreText.color = Color.green;
        yield return new WaitForSeconds(0.1f);
        scoreText.color = Color.white;
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScoreDisplay();
    }

    public void SetScore(int newScore)
    {
        currentScore = newScore;
        UpdateScoreDisplay();
    }

    public int GetScore()
    {
        return currentScore;
    }

    private void UpdateScoreDisplay()
    {
        scoreText.text = $"Score: {currentScore}";
    }
}