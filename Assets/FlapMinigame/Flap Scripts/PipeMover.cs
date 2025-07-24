using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMover : MonoBehaviour
{

    [SerializeField] private float speed = 1;
    [SerializeField] PipeSpawner gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<PipeSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (gameManager.spawningPipes == false)
        {
            Destroy(gameObject);
        }
    }



}
