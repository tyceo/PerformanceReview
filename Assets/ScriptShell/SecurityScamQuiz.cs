using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class SecurityScamQuiz : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public string questionText;
        public string[] answers; // A, B, C, D
    }

    public TextMeshProUGUI questionText;
    public Button buttonA, buttonB, buttonC, buttonD;
    public TextMeshProUGUI resultText;

    public List<Question> questions = new List<Question>();
    private int currentQuestionIndex = 0;

    private int countA = 0, countB = 0, countC = 0, countD = 0;

    void Start()
    {
        resultText.gameObject.SetActive(false);
        ShowQuestion();

        buttonA.onClick.AddListener(() => Answer("A"));
        buttonB.onClick.AddListener(() => Answer("B"));
        buttonC.onClick.AddListener(() => Answer("C"));
        buttonD.onClick.AddListener(() => Answer("D"));
    }

    void ShowQuestion()
    {
        if (currentQuestionIndex < questions.Count)
        {
            Question q = questions[currentQuestionIndex];
            questionText.text = q.questionText;
            buttonA.GetComponentInChildren<TextMeshProUGUI>().text = q.answers[0];
            buttonB.GetComponentInChildren<TextMeshProUGUI>().text = q.answers[1];
            buttonC.GetComponentInChildren<TextMeshProUGUI>().text = q.answers[2];
            buttonD.GetComponentInChildren<TextMeshProUGUI>().text = q.answers[3];
        }
    }

    void Answer(string option)
    {
        switch (option)
        {
            case "A": countA++; break;
            case "B": countB++; break;
            case "C": countC++; break;
            case "D": countD++; break;
        }

        currentQuestionIndex++;

        if (currentQuestionIndex < questions.Count)
        {
            ShowQuestion();
        }
        else
        {
            ShowResult();
        }
    }

    void ShowResult()
    {
        questionText.gameObject.SetActive(false);
        buttonA.gameObject.SetActive(false);
        buttonB.gameObject.SetActive(false);
        buttonC.gameObject.SetActive(false);
        buttonD.gameObject.SetActive(false);

        resultText.gameObject.SetActive(true);

        string result = "";
        if (countA >= countB && countA >= countC && countA >= countD)
            result = "You're a Phishing Email!";
        else if (countB >= countA && countB >= countC && countB >= countD)
            result = "You're a Tech Support Scam!";
        else if (countC >= countA && countC >= countB && countC >= countD)
            result = "You're a USB Drop Attack!";
        else
            result = "You're a Romance Scam!";

        resultText.text = result;
    }
}
