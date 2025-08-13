using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EmailListItem : MonoBehaviour
{
    public TMP_Text senderText;
    public TMP_Text subjectText;
    private Email emailData;
    private EmailManager manager;

    public void Setup(Email email, EmailManager emailManager)
    {
        emailData = email;
        manager = emailManager;
        senderText.text = email.senderName;
        subjectText.text = email.subject;

        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        manager.ShowEmail(emailData);
    }
}
