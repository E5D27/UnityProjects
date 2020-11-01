using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour {

    public int startWait;
    public float newInnerBoundWait;
    public float newInnerBoundWait2;
    public int backgroundColorWait;
    
    public GameObject polygon6;
    public GameObject diamond;
    public GameObject diamondCircle;
    public GameObject diamondCircle2;
    public GameObject bigBallCenter;
    public GameObject player;
    GameObject playerReal;

    public GameObject gameOverPanel;
     
    public GameObject backgroundGradientBlack;

    public GameObject innerBoundRed;
    public GameObject innerBoundBlue;

    BoxCollider2D redCollider;
    CircleCollider2D playerCollider;

    Color colorBlack = Color.black;
    
    Color koyuGreen = new Color32(20, 120, 47,0);

    IEnumerator co;
   
    int count;
    
    public static bool oneMoreChance = true;


    void Start ()
    {       
        count = 0;
        co = Spawn();
       
        Instantiate(player, new Vector2(0, 2), Quaternion.identity);

        playerReal = GameObject.FindGameObjectWithTag("Player");
      
        StartCoroutine(co);
	}
	
    IEnumerator Spawn()                  //Asıl oyunun döndüğü Spawn Couroutine'i Start'dan çağırılıyor.
    {
        //spawnDiamondCircle();
        //yield return new WaitForSeconds(3);
        //spawnDiamondCircle2();

        //spawnCenterBigBall();


        Camera.main.backgroundColor = koyuGreen;
        
        yield return new WaitForSeconds(startWait);

        for (int i = 0; i < 500; i++)
        {
            backgroundGradientBlack.SetActive(false);
            Camera.main.backgroundColor = koyuGreen;
            
            float innerBoundRedSpawnPositionX = Random.Range(-3.50f, 3.50f);
            float innerBoundRedSpawnPositionY = Random.Range(-7.50f, 7.50f);
            
            yield return new WaitForSeconds(backgroundColorWait);

            float innerBoundRedY = Random.Range(4.0f, 13.0f);
            float innerBoundRedX = 1.0f;
            if (innerBoundRedY > 10.0f)
            {
                innerBoundRedX = Random.Range(2.0f, 6.0f);                 //InnerBoundRed in y boyutunu random atıyor ve çıkan y boyutuna göre X boyutunuda farklı aralıklarda random atıyor.
                Debug.Log("a");
            }
            else
            {
                innerBoundRedX = Random.Range(5.0f, 9.0f);
                Debug.Log("b");
            }
            Vector2 innerBoundRedSpawnPosition = new Vector2(innerBoundRedSpawnPositionX, innerBoundRedSpawnPositionY);           
            Vector2 innerBoundRedScale = new Vector2(innerBoundRedX, innerBoundRedY);
            innerBoundRed.transform.localScale = innerBoundRedScale;                                 //InnerBoundRed'i oluşturuyor, o yer ve boyuta göre.
            Instantiate(innerBoundRed, innerBoundRedSpawnPosition, Quaternion.identity);
            //yield return new WaitForSeconds(100);
            yield return new WaitForSeconds(backgroundColorWait);
            spawnObstacles();                                                                                 //SPAWN
            backgroundGradientBlack.SetActive(true);
            Camera.main.backgroundColor = colorBlack;
            
            yield return new WaitForSeconds(newInnerBoundWait);
            spawnObstacles();                                                                                 //SPAWN
            spawnCenterBigBall();
            yield return new WaitForSeconds(newInnerBoundWait2);

            backgroundGradientBlack.SetActive(false);
            Camera.main.backgroundColor = koyuGreen;

            yield return new WaitForSeconds(backgroundColorWait);
            spawnDiamond5stack();                                                                            //SPAWN DIAMOND5 STACK
            float innerBoundBlueY = Random.Range(4.0f, 13.0f);
            float innerBoundBlueX = 1.0f;
            if (innerBoundBlueY > 10.0f)
            {
                innerBoundBlueX = Random.Range(2.0f, 6.0f);
                Debug.Log("c");
            }
            else
            {
                innerBoundBlueX = Random.Range(5.0f, 9.0f);
                Debug.Log("d");
            }
            Vector2 innerBoundBlueSpawnPosition = new Vector2(Random.Range(-3.50f, 3.50f), Random.Range(-7.50f, 7.50f));
            //Vector3 innerBoundBlueSpawnPosition2 = new Vector3((innerBoundRedX/2) + innerBoundRedSpawnPositionX,(innerBoundRedY/2) + innerBoundRedSpawnPositionY,5); //Önceki bounda bağlı yarat.
            Vector2 innerBoundBlueScale = new Vector2(innerBoundBlueX, innerBoundBlueY);
            innerBoundBlue.transform.localScale = innerBoundBlueScale;
            Instantiate(innerBoundBlue, innerBoundBlueSpawnPosition, Quaternion.identity);
            
            yield return new WaitForSeconds(backgroundColorWait);
            spawnObstacles();                                                                                  //SPAWN
            spawnDiamondCircle();
            backgroundGradientBlack.SetActive(true);
            Camera.main.backgroundColor = colorBlack;
            Debug.Log("f");
            
            yield return new WaitForSeconds(newInnerBoundWait);
            spawnObstacles();                                                                                 //SPAWN
            spawnDiamondCircle2();
            yield return new WaitForSeconds(newInnerBoundWait2);
        }
    }

  
    void Update()
    {             
        if (playerReal == null && count == 0)
        {
            count++;
            StopCoroutine(co);
            Debug.Log("YESSS");
            CallGameOver();           
        }
       
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                if (oneMoreChance)
                {
                    oneMoreChance = false;
                    SceneManager.LoadScene("Game"); //Score ekledikten sonra, Oyunu yeniden başlat ama önceki skor kalsın ekle. (Bi static başlangıç skoru ekle sonuna kadar ad izlenirse, oyun baştan başlasın ama skor devam etsin)
                }
                else SceneManager.LoadScene("MainMenu");
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                SceneManager.LoadScene("MainMenu");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    public void ShowRegularAd()
    {
        if (Advertisement.IsReady("video"))
        {          
            Advertisement.Show("video");
        }

    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void CallGameOver()
    {
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1);
        gameOverPanel.SetActive(true);
        yield break;
    }

    //---------------------------- Obstacle Spawnlayan Methodlar ------------------------------------------------

    void spawnObstacles()   //Random obstacleları spawnlayan method.
    {
        for (int i = 0; i < 10; i++)
        {
            float polygon6SpawnPositionX = 5.0f;
            float polygon6SpawnPositionY = 5.0f;

            int region = Random.Range(0, 4);

            if (region == 0)
            {
                polygon6SpawnPositionX = -7;
                polygon6SpawnPositionY = Random.Range(-13.0f, 13.0f);
            }
            if (region == 1)
            {
                polygon6SpawnPositionX = 7;
                polygon6SpawnPositionY = Random.Range(-13.0f, 13.0f);
            }
            if (region == 2)
            {
                polygon6SpawnPositionY = 11;
                polygon6SpawnPositionX = Random.Range(-8.0f, 8.0f);
            }
            if (region == 3)
            {
                polygon6SpawnPositionY = -11;
                polygon6SpawnPositionX = Random.Range(-8.0f, 8.0f);
            }

            Vector2 polygon6SpawnPosition = new Vector2(polygon6SpawnPositionX, polygon6SpawnPositionY);
            Instantiate(polygon6, polygon6SpawnPosition, Quaternion.identity);
        }
    }


    void spawnDiamond5stack()  //Sağ üstten sol alta, sonra tekrar sağa sola giden 5 stack diamond u spawnlayan method
    {
        float diamondSpawnPositionX = 1.0f;
        float diamondSpawnPositionY = 11.0f;
      
        Vector2 diamondSpawnPosition = new Vector2(diamondSpawnPositionX, diamondSpawnPositionY);

        Instantiate(diamond, diamondSpawnPosition, Quaternion.identity);
        Instantiate(diamond, diamondSpawnPosition + new Vector2(1, 0), Quaternion.identity);
        Instantiate(diamond, diamondSpawnPosition + new Vector2(2, 0), Quaternion.identity);
        Instantiate(diamond, diamondSpawnPosition + new Vector2(3, 0), Quaternion.identity);
        Instantiate(diamond, diamondSpawnPosition + new Vector2(4, 0), Quaternion.identity);       
    }

    void spawnDiamondCircle()  //Sağ üstten sol alta giden diamond circle ı spawnlayan method
    {
        float diamondSpawnPositionX = 10.0f;
        float diamondSpawnPositionY = 20.0f;

        Vector2 diamondSpawnPosition = new Vector2(diamondSpawnPositionX, diamondSpawnPositionY);

        Instantiate(diamondCircle, diamondSpawnPosition, Quaternion.identity);
    }

    void spawnDiamondCircle2()  //Sol üstten sağ alta giden diamond circle ı spawnlayan method
    {
        float diamondSpawnPositionX = -10.0f;
        float diamondSpawnPositionY = 15.0f;

        Vector2 diamondSpawnPosition = new Vector2(diamondSpawnPositionX, diamondSpawnPositionY);

        Instantiate(diamondCircle2, diamondSpawnPosition, Quaternion.identity);
    }

    void spawnCenterBigBall()  //Tam ortadan aşağıya 4'e 4'lük bir top bırakıyor.
    {
        float circleSpawnPositionX = 0;
        float circleSpawnPositionY = 13;

        Vector2 circleSpawnPosition = new Vector2(circleSpawnPositionX, circleSpawnPositionY);

        Instantiate(bigBallCenter, circleSpawnPosition, Quaternion.identity);
    }

    //IEnumerator Ad()
    //{
    //    yield return new WaitForSeconds(2.5f);

    //    if (Advertisement.IsReady("rewardedVideo"))
    //    {
    //        var options = new ShowOptions { resultCallback = HandleShowResult };
    //        Advertisement.Show("rewardedVideo", options);
    //    }
    //}
}
