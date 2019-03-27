using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float minSwipeDistY;

    public float minSwipeDistX;

    private Vector2 startPos;

    void Update()
    {
        //#if UNITY_ANDROID
        if (Input.touchCount > 0)

        {

            Touch touch = Input.touches[0];



            switch (touch.phase)

            {

                case TouchPhase.Began:

                    startPos = touch.position;

                    break;



                case TouchPhase.Ended:

                    float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

                    if (swipeDistVertical > minSwipeDistY)

                    {

                        float swipeValue = Mathf.Sign(touch.position.y - startPos.y);

                        if (swipeValue > 0)//up swipe
                        {

                        }

                            //Jump ();

                        else if (swipeValue < 0)//down swipe
                        {

                        }

                            //Shrink ();

                    }

                    float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;

                    if (swipeDistHorizontal > minSwipeDistX)

                    {

                        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);

                        if (swipeValue > 0 || swipeValue < 0)//right swipe
                        {
                            swipeValue=Mathf.Clamp(swipeValue, -90, 90);
                            this.transform.eulerAngles = new Vector3(0f, swipeValue, 0f);

                        }

                            //MoveRight ();

                        else if (swipeValue < 0)//left swipe
                        {

                        }

                            //MoveLeft ();

                    }
                    break;
            }
        }
    }
}
