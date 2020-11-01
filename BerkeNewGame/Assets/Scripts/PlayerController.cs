using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {


    float deltaX, deltaY;
    Rigidbody2D rb;
    
    public float friction; //0.4f
    public float bouncy;  //0.75f

    public GameObject deadEffect;

    bool isDragging;

    Vector2 offset;

    public int speed;

    void Start () {
       
        rb = GetComponent<Rigidbody2D>();



        PhysicsMaterial2D mat = new PhysicsMaterial2D();
        mat.bounciness = bouncy;
        mat.friction = friction;
        //GetComponent<CircleCollider2D>().sharedMaterial = mat;
        rb.gravityScale = 0;
        rb.freezeRotation = false;
    }

    void Update()
    {
        //Touch _touch = Input.GetTouch(0);

        if (Input.touchCount > 0)
        {
            // screen has been touched, store the touch 
            Touch _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Began)
            {
                isDragging = true;

                offset = Camera.main.ScreenToWorldPoint(new Vector2(_touch.position.x, _touch.position.y)) - gameObject.transform.position;

            }
            else if (_touch.phase == TouchPhase.Ended)
            {
                offset = Vector2.zero;
                isDragging = false;
            }

        }

        if (isDragging)
        {
            Touch _touch = Input.GetTouch(0);
            Vector2 _dir = Camera.main.ScreenToWorldPoint(new Vector2(_touch.position.x, _touch.position.y));
            _dir = _dir - offset;

            gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, _dir, Time.deltaTime * speed);

        }


    } // end

    //void FixedUpdate () {


    //       if (Input.touchCount > 0)
    //       {
    //           Touch touch = Input.GetTouch(0);

    //           Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

    //           switch (touch.phase)
    //           {
    //               case TouchPhase.Began:
    //                   deltaX = 0.0f;
    //                   deltaY = 0.0f;

    //                   deltaX = touchPos.x - gameObject.transform.position.x;
    //                   deltaY = touchPos.y - gameObject.transform.position.y;

    //                   break;

    //               case TouchPhase.Moved:

    //                   rb.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY) * 1.1f);  // İstediğin katsayı ile çarp, doğru hız için.

    //                   break;

    //               case TouchPhase.Ended:
    //                   deltaX = 0;
    //                   deltaY = 0;

    //                   break;
    //           }
    //       }



    //   }


    void OnDestroy()
    {
        Debug.Log("Game Over");

        Destroy(Instantiate(deadEffect, gameObject.transform.position, Quaternion.identity),3.0f);     

    }

    


}
