using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class TypingMinigame : MonoBehaviour
{
    public TMP_Text wordDisplay;
    public TMP_InputField inputField;
    public TMP_Text timerText;
    public TMP_Text scoreText;

    public float CoolDown = 5;
    public float gameDuration = 7f;
    public float bonusTimePerCorrectWord = 1.5f; // ⬅️ Adds time per correct word

    private float timer;
    private bool isGameActive = false;
    private int score = 0;

    private List<string> wordList = new List<string> {
        "security", "email", "login", "password", "report",
        "access", "server", "phishing", "malware", "threat",
        "network", "user", "office", "data", "firewall",
        "data breach", "cyber attack", "zero trust", "ransomware", "social engineering" // ⬅️ Multi-word phrases
    };

    private string currentWord;

    void Start()
    {
        inputField.onSubmit.AddListener(CheckInput);
        StartGame();
    }

    void Update()
    {
        if (isGameActive)
        {
            timer -= Time.deltaTime;
            UpdateTimerText();

            if (timer <= 0f)
            {
                EndGame();
            }
        }
    }

    void StartGame()
    {
        isGameActive = true;
        timer = gameDuration;
        score = 0;
        ShowNewWord();
        inputField.text = "";
        inputField.interactable = true;
        inputField.ActivateInputField(); // ⬅️ Auto-focus input
        scoreText.text = "Score: 0";
    }

    void ShowNewWord()
    {
        int randomIndex = Random.Range(0, wordList.Count);
        currentWord = wordList[randomIndex];
        wordDisplay.text = currentWord;
    }

    void CheckInput(string userInput)
    {
        if (!isGameActive) return;

        if (userInput.Trim().ToLower() == currentWord.ToLower())
        {
            ScoreManager.Instance.AddScore(1);
            score++;
            scoreText.text = "Score: " + score;

            // ⬅️ Add bonus time for correct word
            timer += bonusTimePerCorrectWord;

            ShowNewWord();
        }

        inputField.text = "";
        inputField.ActivateInputField(); // Refocus
    }

    void EndGame()
    {
        isGameActive = false;
        timerText.text = "Time's up! Try again in a few seconds";
        inputField.interactable = false;

        Debug.Log("Final Score: " + score);
        StartCoroutine(RestartAfterCooldown());
    }

    IEnumerator RestartAfterCooldown()
    {
        yield return new WaitForSeconds(CoolDown);
        StartGame();
    }

    void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.Ceil(timer).ToString();
    }
}
