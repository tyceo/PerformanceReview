using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class LoadCounter : MonoBehaviour
{
    public static LoadCounter Instance;

    public int sceneLoadCount = 0;
    public int DayOneScore = 0;
    public int DayTwoScore = 0;
    public int DayThreeScore = 0;
    public int DayFourScore = 0;
    public int DayFiveScore = 0;

    public int WrongAmount = 0;

    private EmailManager emailManager;

    public GameObject Cover;

    private TMP_Text wrongAmountTMP;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(UpdateDayTextNextFrame());
    }

    public void AddWrong()
    {
        WrongAmount++;

        if (wrongAmountTMP == null)
            wrongAmountTMP = FindTMPInScene("WrongAmountText");

        if (wrongAmountTMP != null)
            wrongAmountTMP.text = WrongAmount.ToString();
    }

    public void ReadScore()
    {
        string dayName = sceneLoadCount switch
        {
            1 => "Monday",
            2 => "Monday",
            3 => "Monday",
            4 => "Monday",
            5 => "Monday",
            _ => null
        };

        if (dayName == null) return;

        GameObject dayObj = GameObject.Find(dayName);
        if (dayObj == null)
        {
            Debug.LogWarning($"Day object '{dayName}' not found in the scene!");
            return;
        }

        TMP_Text dayTMP = dayObj.GetComponent<TMP_Text>();
        if (dayTMP == null)
        {
            Debug.LogWarning($"TMP_Text component not found on '{dayName}' object!");
            return;
        }

        switch (sceneLoadCount)
        {
            case 1:
                dayTMP.text = "Monday";
                DayOneScore = ScoreManager.Instance.GetScore();
                Debug.Log($"Day One Score: {DayOneScore}");
                break;
            case 2:
                dayTMP.text = "Tuesday";
                DayTwoScore = ScoreManager.Instance.GetScore();
                Debug.Log($"Day Two Score: {DayTwoScore}");
                break;
            case 3:
                dayTMP.text = "Wednesday";
                DayThreeScore = ScoreManager.Instance.GetScore();
                Debug.Log($"Day Three Score: {DayThreeScore}");
                break;
            case 4:
                dayTMP.text = "Thursday";
                DayFourScore = ScoreManager.Instance.GetScore();
                Debug.Log($"Day Four Score: {DayFourScore}");
                break;
            case 5:
                dayTMP.text = "Friday";
                DayFiveScore = ScoreManager.Instance.GetScore();
                Debug.Log($"Day Five Score: {DayFiveScore}");
                break;
        }
    }

    private IEnumerator UpdateDayTextNextFrame()
    {
        yield return null;
        ReadScore();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject emailManagerObj = GameObject.Find("EmailManager");

        if (emailManagerObj != null)
        {
            emailManager = emailManagerObj.GetComponent<EmailManager>();

            if (emailManager != null)
            {
                Debug.Log("EmailManager found.");

                sceneLoadCount++;
                Debug.Log($"Scene loaded {sceneLoadCount} times");
                if (sceneLoadCount == 1)
                {
                    StartCoroutine(UpdateDayTextNextFrame());
                    StartCoroutine(DelayedReveal());
                }
                if (sceneLoadCount == 2)
                {
                    StartCoroutine(UpdateDayTextNextFrame());
                    StartCoroutine(DelayedReveal2());
                }
                if (sceneLoadCount == 3)
                {
                    StartCoroutine(UpdateDayTextNextFrame());
                    StartCoroutine(DelayedReveal3());
                }
                if (sceneLoadCount == 4)
                {
                    StartCoroutine(UpdateDayTextNextFrame());
                    StartCoroutine(DelayedReveal4());
                }
                if (sceneLoadCount == 5)
                {
                    StartCoroutine(UpdateDayTextNextFrame());
                    StartCoroutine(DelayedReveal5());
                }
                if (sceneLoadCount == 6)
                {
                    Application.Quit();
                }
            }
            else
            {
                Debug.LogWarning("EmailManager component not found on the GameObject.");
            }
        }
        else
        {
            Debug.LogWarning("EmailManager GameObject not found in the scene.");
        }
    }

    private IEnumerator DelayedReveal()
    {
        yield return new WaitForSeconds(1f);
        if (emailManager != null) emailManager.RevealNextEmail();
    }
    private IEnumerator DelayedReveal2()
    {
        yield return new WaitForSeconds(1f);
        if (emailManager != null)
            emailManager.RevealEmail2();
    }
    private IEnumerator DelayedReveal3()
    {
        yield return new WaitForSeconds(1f);
        if (emailManager != null)
            emailManager.RevealEmail3();
    }
    private IEnumerator DelayedReveal4()
    {
        yield return new WaitForSeconds(1f);
        if (emailManager != null)
            emailManager.RevealEmail4();
    }
    private IEnumerator DelayedReveal5()
    {
        yield return new WaitForSeconds(1f);

        if (emailManager != null)
            emailManager.RevealEmail5();

        // Find Cover even if inactive
        if (Cover == null)
            Cover = FindInSceneEvenIfInactive("Cover");
        if (Cover != null)
            Cover.SetActive(true);
        else
            Debug.LogWarning("Cover GameObject not found (even inactive).");
    }

    // Helper to find a scene GameObject even if inactive
    private GameObject FindInSceneEvenIfInactive(string name)
    {
        var all = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (var go in all)
        {
            if (go.name == name && go.scene.IsValid())
                return go;
        }
        return null;
    }

    private TMP_Text FindTMPInScene(string name)
    {
        TMP_Text[] allTMP = Resources.FindObjectsOfTypeAll<TMP_Text>(); // removed 'true'
        foreach (TMP_Text t in allTMP)
        {
            if (t.name == name && t.gameObject.scene.IsValid())
                return t;
        }
        return null;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
