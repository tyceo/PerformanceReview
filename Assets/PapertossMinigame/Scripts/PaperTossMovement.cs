using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
    {

        public SpringJoint2D spring;


        void Awake()
        {

            spring = this.gameObject.GetComponent<SpringJoint2D>(); //"spring" is the SpringJoint2D component that I added to my object

            spring.connectedAnchor = gameObject.transform.position;//i want the anchor position to start at the object's position

        }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnMouseDown();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            OnMouseUp();
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        { 
        OnMouseDrag();
        }
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


