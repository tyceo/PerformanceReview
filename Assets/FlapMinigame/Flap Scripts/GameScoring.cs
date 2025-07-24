using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GameScoring : MonoBehaviour
{

    [SerializeField] private GameObject playerStartingPosition;
    [SerializeField] PipeSpawner gameManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }


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
            ResetPlayerPosition();
            gameManager.spawningPipes = false;
            StartCoroutine(RestartPipeSpawning());
            Debug.Log("player failed");
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
