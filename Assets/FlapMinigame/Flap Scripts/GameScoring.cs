using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GameScoring : MonoBehaviour
{

    [SerializeField] private GameObject playerStartingPosition;
    [SerializeField] PipeSpawner gameManager;
    [SerializeField] bool ranScripts = false;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("Goal!");
        }


    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Goal")
        {
            PlayerFailure();

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf && ranScripts == false)
        {
            Debug.Log("ran");
            PlayerFailure();
            ranScripts = true;
        }
    }

    void PlayerFailure()
    {

        ResetPlayerPosition();
        gameManager.spawningPipes = false;
        StartCoroutine(RestartPipeSpawning());
        Debug.Log("player failed");
    }    


    private void ResetPlayerPosition()
    {
        this.gameObject.transform.position = playerStartingPosition.transform.position;
    }

    private IEnumerator RestartPipeSpawning()
    {
        yield return new WaitForSeconds(0.7f);
        gameManager.spawningPipes = true;
        
        
    }

}
