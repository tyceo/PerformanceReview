using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PaperTossMovement : MonoBehaviour
    {

        public SpringJoint2D spring;
        public GameObject invisibleWall;
        public float resetSpeed = 2.8f;


        void Awake()
        {
            invisibleWall = GameObject.FindGameObjectWithTag("invisibleWall");
            
            spring = this.gameObject.GetComponent<SpringJoint2D>(); 

            spring.connectedAnchor = gameObject.transform.position;

        }

    private void Update()
    {
       


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            OnMouseDown();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            invisibleWall.GetComponent<BoxCollider2D>().enabled = false;
            OnMouseUp();
            StartCoroutine(StartCountdown());
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        { 
        OnMouseDrag();
        
        invisibleWall.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(resetSpeed);


        gameObject.GetComponent<PaperTossCollisions>().CreateNewPaperBall();

        Destroy(gameObject);
    }





    void OnMouseDown()
        {

            spring.enabled = true;//I'm reactivating the SpringJoint2D component each time I'm clicking on my object becouse I'm disabling it after I'm releasing the mouse click so it will fly in the direction i was moving my mouse

        }





        void OnMouseDrag()
        {

            if (spring.enabled == true)
            {

                Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);//getting cursor position

                spring.connectedAnchor = cursorPosition;//the anchor get's cursor's position


            }
        }


        void OnMouseUp()
        {

            spring.enabled = false;//disabling the spring component

        }


    }


