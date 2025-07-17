using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clicking : MonoBehaviour
{
    Vector3 mousePos;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 mousePos = Input.mousePosition;

     
        
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
        
        
        transform.position = worldPos;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Square")
        {
            Debug.Log("Test1");
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("TestDone");
            }
        }
        
    }
}
