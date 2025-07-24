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
    private float timer;
    private bool isGameActive = false;

    private List<string> wordList = new List<string> {
        "security", "email", "login", "password", "report",
        "access", "server", "phishing", "malware", "threat",
        "network", "user", "office", "data", "firewall"
    };

    private string currentWord;
    private int score = 0;

    void Start()
    {
        timer = gameDuration;
        score = 0;
        UpdateTimerText();
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
        inputField.ActivateInputField();

        isGameActive = true;
        timerText.text = "Time's up!";
        inputField.interactable = true;
    }

    void ShowNewWord()
    {
        ScoreManager.Instance.AddScore(1);
        int randomIndex = Random.Range(0, wordList.Count);
        currentWord = wordList[randomIndex];
        wordDisplay.text = currentWord;
    }

    void CheckInput(string userInput)
    {
        if (!isGameActive) return;

        if (userInput.Trim().ToLower() == currentWord.ToLower())
        {
            score++;
            scoreText.text = "Score: " + score;
            ShowNewWord();
            inputField.text = "";
            inputField.ActivateInputField(); // Refocus
        }
        else
        {
            inputField.text = "";
            inputField.ActivateInputField();
        }
    }

    void EndGame()
    {
        isGameActive = false;
        timerText.text = "Time's up!";
        inputField.interactable = false;

        // OPTIONAL: Save score to a game manager or HR review system
        Debug.Log("Final Score: " + score);
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(CoolDown);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        StartGame();
    }

    void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.Ceil(timer).ToString();
    }
}
