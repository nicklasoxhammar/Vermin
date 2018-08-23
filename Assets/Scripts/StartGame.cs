using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

	void Start () {

        gameObject.GetComponentInChildren<Text>().text = "High Score: " + PlayerPrefs.GetInt("highscore", 0);

    }
	

    public void StartGameScene() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
