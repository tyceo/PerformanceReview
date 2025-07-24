using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1Manager : MonoBehaviour
{
    [SerializeField] private int scoreIncreaseAmount = 1;

    [SerializeField] private float distance = 0.2f; // How far to move each way
    [SerializeField] private float speed = 1f; // Movement speed

    private Vector3 startPosition;
    private bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rightTarget = startPosition + Vector3.right * distance;
        Vector3 leftTarget = startPosition + Vector3.left * distance;

        // Determine direction and move
        if (movingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, rightTarget, speed * Time.deltaTime);

            // Switch direction when reaching target
            if (Vector3.Distance(transform.position, rightTarget) < 0.001f)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, leftTarget, speed * Time.deltaTime);

            // Switch direction when reaching target
            if (Vector3.Distance(transform.position, leftTarget) < 0.001f)
            {
                movingRight = true;
                AddToScore();
            }
        }
    }
    // Example method that increases score
    public void AddToScore()
    {
        // Basic score increase
        ScoreManager.Instance.AddScore(scoreIncreaseAmount);
    }

    
}
