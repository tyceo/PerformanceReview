using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperTossCollisions : MonoBehaviour
{
    [SerializeField] private PaperTossScoring manager;
    [SerializeField] private GameObject paperballPrefab;
    [SerializeField] private Transform spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("Score");

            //add manager functions

            Instantiate(paperballPrefab, new Vector3(-5.81f, 0, 0), Quaternion.identity);
            
            Destroy(gameObject);
        }
    }


}
