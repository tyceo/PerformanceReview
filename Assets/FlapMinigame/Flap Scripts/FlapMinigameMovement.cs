using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlapMinigameMovement : MonoBehaviour
{
    [SerializeField] private float velocity = 1.5f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * velocity;
        }
    }
}
