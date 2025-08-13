using UnityEngine;

[System.Serializable]
public class Email
{
    public string senderName;
    public string subject;
    [TextArea(5, 10)] public string body;

    [Header("Quiz Options")]
    public string textA;
    public string textB;
    public string textC;
    public string textD;

    [Header("Correct Answers")]
    public string[] correctAnswers;

    public bool hasBeenAnswered = false;
}
