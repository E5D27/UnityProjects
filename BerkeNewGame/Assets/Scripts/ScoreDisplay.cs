using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour {

    private TextMeshProUGUI scoreText;
    static float fireRate = 0.1f;
    static float nextFire = 0.0f;
    static float adRate = 1.0f;
    static float adFire = 0.0f;
    public static int score = 0;
    public int scoreRef = 0;
    int counter = 12;

    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI adCounter;
    public GameObject adButton;
    //public GameObject counterDisap;

    void Start ()
    {       
        scoreText = GetComponent<TextMeshProUGUI>();
        bestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("BestScore", 0).ToString();
    }


    void FixedUpdate () {

        scoreText.text = "Score: " + score.ToString();

        if (Time.time > nextFire && GameObject.FindGameObjectWithTag("Player"))
        {
            nextFire = Time.time + fireRate;
            score++;                                           //Player hayattayken score'u arttır.
            scoreRef = score;
        }
        else
        {
            if (Time.time > adFire && GameObject.FindGameObjectWithTag("Player") == null)
            {
                adFire = Time.time + adRate;
                if (counter == 0)
                {
                    counter = 0;                        //Player ölünce score'u durdur ve 10 saniye counter bitince rewarded ad butonunu kaldır.
                    adButton.SetActive(false);
                    adCounter.text = " ";
                }
                else
                {
                    counter--;
                    adCounter.text = (counter).ToString();
                }
                //adCounter.text = (counter).ToString();
                
            }
            

            currentScoreText.text = "Score: " + score.ToString();

            if (score > PlayerPrefs.GetInt("BestScore", 0))
            {
                PlayerPrefs.SetInt("BestScore", score);                    //High score'u tutuyor, youtube'daki videoda aynısını anlatıyor (PlayerPrefs).
                bestScoreText.text = "Best Score: " + score.ToString();
            }
        }
    }


}
