using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadCounter : MonoBehaviour
{
    public static LoadCounter Instance;

    public int sceneLoadCount = 0;
    public int DayOneScore = 0; // Score for Day One
    public int DayTwoScore = 0; // Score for Day Two
    public int DayThreeScore = 0; // Score for Day Three
    public int DayFourScore = 0; // Score for Day Four
    public int DayFiveScore = 0; // Score for Day Five

    public int WrongAmount = 0;

    private EmailManager emailManager;  // Reference to the script component
     

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
    public void ReadScore()
    {
        Debug.Log("read score here");
        if (sceneLoadCount == 1)
        {
            DayOneScore = ScoreManager.Instance.GetScore();
            Debug.Log($"Day One Score: {DayOneScore}");
        }
        else if (sceneLoadCount == 2)
        {
            DayTwoScore = ScoreManager.Instance.GetScore();
            Debug.Log($"Day Two Score: {DayTwoScore}");
        }
        else if (sceneLoadCount == 3)
        {
            DayThreeScore = ScoreManager.Instance.GetScore();
            Debug.Log($"Day Three Score: {DayThreeScore}");
        }
        else if (sceneLoadCount == 4)
        {
            DayFourScore = ScoreManager.Instance.GetScore();
            Debug.Log($"Day Four Score: {DayFourScore}");
        }
        else if (sceneLoadCount == 5)
        {
            DayFiveScore = ScoreManager.Instance.GetScore();
            Debug.Log($"Day Five Score: {DayFiveScore}");
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find the EmailManager GameObject
        GameObject emailManagerObj = GameObject.Find("EmailManager");

        if (emailManagerObj != null)
        {
            // Get the EmailManager script component
            emailManager = emailManagerObj.GetComponent<EmailManager>();

            if (emailManager != null)
            {
                Debug.Log("EmailManager found.");

                sceneLoadCount++;
                Debug.Log($"Scene loaded {sceneLoadCount} times");
                if (sceneLoadCount == 1)
                {

                    StartCoroutine(DelayedReveal());
                }
                if (sceneLoadCount == 2)
                {
                    
                    StartCoroutine(DelayedReveal2());
                }
                if (sceneLoadCount == 3)
                {

                    StartCoroutine(DelayedReveal3());
                }
                if (sceneLoadCount == 4)
                {

                    StartCoroutine(DelayedReveal4());
                }
                if (sceneLoadCount == 5)
                {

                    StartCoroutine(DelayedReveal5());
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
        yield return new WaitForSeconds(1f);  // wait 1 second

        if (emailManager != null)
        {
            //emailManager.RevealNextEmail();
            emailManager.RevealNextEmail();
        }
    }
    private IEnumerator DelayedReveal2()
    {
        yield return new WaitForSeconds(1f);  // wait 1 second

        if (emailManager != null)
        {
            emailManager.RevealNextEmail();
            emailManager.RevealNextEmail();
        }
    }
    private IEnumerator DelayedReveal3()
    {
        yield return new WaitForSeconds(1f);  // wait 1 second

        if (emailManager != null)
        {
            emailManager.RevealNextEmail();
            emailManager.RevealNextEmail();
            emailManager.RevealNextEmail();
        }
    }
    private IEnumerator DelayedReveal4()
    {
        yield return new WaitForSeconds(1f);  // wait 1 second

        if (emailManager != null)
        {
            emailManager.RevealNextEmail();
            emailManager.RevealNextEmail();
            emailManager.RevealNextEmail();
            emailManager.RevealNextEmail();
        }
    }
    private IEnumerator DelayedReveal5()
    {
        yield return new WaitForSeconds(1f);  // wait 1 second

        if (emailManager != null)
        {
            emailManager.RevealNextEmail();
            emailManager.RevealNextEmail();
            emailManager.RevealNextEmail();
            emailManager.RevealNextEmail();
            emailManager.RevealNextEmail();
            
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
