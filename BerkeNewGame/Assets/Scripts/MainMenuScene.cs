using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScene : MonoBehaviour {


    int backgroundColor;

    public GameObject mainMenuPanelRed;
    public GameObject mainMenuPanelBlue;

    ScoreDisplay score;

	void Start () {

        GameController.oneMoreChance = true;
        ScoreDisplay.score = 0;
        backgroundCol();
    }
	
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    void backgroundCol()
    {
        backgroundColor = Random.Range(0, 2);

        if (backgroundColor == 0)
        {
            mainMenuPanelRed.SetActive(true);
        }
        if (backgroundColor == 1)
        {
            mainMenuPanelBlue.SetActive(true);
        }


    }


}
