using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipe : MonoBehaviour
{
    Vector2 startTouch, swipeDelta;
    bool swipeLeft, swipeRight, swipeUp, swipeDown,tap;
    bool isDragging = false;
    Vector2 desiredPos;
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //making every time the swipe movement back to false once then operation get commpleted 
        tap=swipeLeft = swipeRight = swipeUp = swipeDown = false;
        if (Input.GetMouseButtonDown(0))//when pressing
        {
            tap = true;
            isDragging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))//when releasing
        {
            Reset();
            isDragging = false;
        }

        #region Mobile Inputs
        if(Input.touchCount> 0) //there we are touching the screen 
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;
            }
            else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                Reset();
                isDragging = false;
            }
        }

        #endregion

        swipeMovements();

        //crossign the line/bounds
        if(swipeDelta.magnitude > 100)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                if(x < 0)
                {
                    swipeLeft = true;
                }
                else
                {
                    swipeRight = true;
                }
            }
            else
            {
                if(y < 0)
                {
                    swipeDown = true;
                }
                else
                {
                    swipeUp = true;
                }
            }
            Reset();
        }

        //find the difference 
        swipeDelta = Vector2.zero;
   
            if(isDragging)
            {
                if(Input.touchCount>0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
                else if(Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
            }
        
    }
    private void Reset()//only called in the editor
    {
        startTouch = swipeDelta =Vector2.zero;
        isDragging = false;
    }
    void swipeMovements()
    {
        if(swipeDown)
        {
            desiredPos = Vector2.down;
        }
        if(swipeLeft)
        {
            desiredPos = Vector2.left;
        }
        if(swipeRight)
        {
            desiredPos = Vector2.right;
        }
        if(swipeUp)
        {
            desiredPos = Vector2.up;
        }

        transform.position = Vector2.MoveTowards(this.transform.position, desiredPos, speed * Time.deltaTime);
    }
}
