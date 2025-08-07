using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperTossCollisions : MonoBehaviour
{
    [SerializeField] private PaperTossScoring manager;
    [SerializeField] private GameObject paperballPrefab;
    [SerializeField] private Transform spawnPos;

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("Score");
            ScoreManager.Instance.AddScore(1);

            //add manager functions



            GameObject clone =  Instantiate(paperballPrefab, new Vector3(-5.81f, 0, 0), Quaternion.identity);

            //Instantiate(paperballPrefab, spawnPos);

            //paperballPrefab.transform.position = new Vector3(-5.81f, 0, 0);

            clone.transform.SetParent(spawnPos);

            Destroy(gameObject);
        }
    }


    public void CreateNewPaperBall()
    {

        GameObject clone = Instantiate(paperballPrefab, new Vector3(-5.81f, 0, 0), Quaternion.identity);

        clone.transform.SetParent(spawnPos);

        
    }




}
