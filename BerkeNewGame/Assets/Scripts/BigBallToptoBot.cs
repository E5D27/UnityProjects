using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBallToptoBot : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("abc");  //Player'i öldür 

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
    }
}
