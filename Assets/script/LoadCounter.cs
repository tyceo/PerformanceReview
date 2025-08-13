using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadCounter : MonoBehaviour
{
    public static LoadCounter Instance;

    public int sceneLoadCount = 0;

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

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
