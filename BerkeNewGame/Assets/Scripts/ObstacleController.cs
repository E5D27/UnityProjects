using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {


    Rigidbody2D rigid;
    public float speed;
    
    void Start()  //Random objeler etrafta ve hepsini ekrana doğru atıyor, GameController'daki spawnObstacles burdaki objeleri istenen yerlerinde oluşturuyor, Bu class da onlara yön (velocity) veriyor.
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();

        rigid.angularVelocity = 400.0f;

        if (gameObject.transform.position.x > 0 && gameObject.transform.position.y > 0)
        {
            rigid.velocity = new Vector2(Random.Range(-13.0f,0.0f), Random.Range(-13.0f,0.0f)) * speed;
        }

        if (gameObject.transform.position.x < 0 && gameObject.transform.position.y > 0)
        {
            rigid.velocity = new Vector2(Random.Range(0.0f, 13.0f), Random.Range(-13.0f, 0.0f)) * speed;
        }

        if (gameObject.transform.position.x < 0 && gameObject.transform.position.y < 0)
        {
            rigid.velocity = new Vector2(Random.Range(0.0f, 13.0f), Random.Range(0.0f, 13.0f)) * speed;
        }

        if (gameObject.transform.position.x > 0 && gameObject.transform.position.y < 0)
        {
            rigid.velocity = new Vector2(Random.Range(-13.0f, 0.0f), Random.Range(0.0f, 13.0f)) * speed;
        }
    }

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
