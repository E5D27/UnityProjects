using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCircle2 : MonoBehaviour
{

    Rigidbody2D rigid;
    float speed = 3;


    void Start()  //Yuvarlak halinde 8 tane diamond oluşturuyor ve bun yuvarlak sağ üstten sol aşağı doğru gidiyor. Bu class'ın yönlendirdiği objeleri GameController'da spawnDiamondCircle oluşturuyor.
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        rigid.angularVelocity = 400.0f;
        rigid.velocity = new Vector2(1.0f, -1.75f) * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("abc");  //Player'i öldür 

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
        else
        {
            //rigid.velocity = new Vector2(0, 0);
            //print("LOLLLLLLLLLLLLLLLLLLLL");
        }
    }

}
