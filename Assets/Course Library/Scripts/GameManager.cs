using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public GameObject GOver;
    public PlayerController playerController;
    public GameObject winGo;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        PlayerPrefs.SetInt("obj", 0);
        PlayerPrefs.SetInt("coins", 0);
    }
    public void GameOver()
    {
GOver.SetActive(true);
        //Time.timeScale = 0.0f;
    }
    public void RestartGame(string name)
    {
         Time.timeScale = 1.0f;
        //PlayerPrefs.DeleteAll();
        Physics.gravity *= 0.5f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Update is called once per frame
    void Update()
    {
        coinText.text ="C:"+ PlayerPrefs.GetInt("coins").ToString();
        if (playerController.gameOver)
        {
            GameOver();

        }
        if (PlayerPrefs.GetInt("obj") >= 20)
        {
            winGo.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
