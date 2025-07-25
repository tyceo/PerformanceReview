using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] GameObject pipe;
    [SerializeField] float maxTime = 1.5f;
    [SerializeField] float heightRange;
    [SerializeField] public bool spawningPipes = true;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
       if (timer > maxTime)
        {
            SpawnPipe();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        if (spawningPipes)
        {
            Vector3 spawnPos = transform.position + new Vector3(6, Random.Range(-heightRange, heightRange) + 2.5f);
            GameObject pipes = Instantiate(pipe, spawnPos, Quaternion.identity, this.transform);

            Destroy(pipes, 20f);

            
        }
    }

    void StopSpawningPipes()
    {
        spawningPipes = false;
    }

}
