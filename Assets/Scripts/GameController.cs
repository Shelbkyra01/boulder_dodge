using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    [SerializeField]Transform Respawn;

    public GameObject Boulder;
    
    public static GameController instance;

    public int lives = 3;
    public GameObject livesCanvas;
    public Text livesText;

    public GameObject GameOverPanel;
    bool gameOver = false;

    
    

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(livesCanvas);
    }
    
    void Start()
    {
       
    }

    void Update()
    {
        livesText.text = "Lives: " + lives.ToString();
    }

    

    public void DecreaseLife()
    {
        if (lives > 0)
        {
            lives --;
           
        }

        if (lives<= 0)
        {
          
            GameOver();
        }
    }

    public void GameOver()
    {
        Spawner.instance.StopCoroutine("SpawnBoulders");

        CoinSpawner.instance.StopCoroutine("SpawnCoins");

        GameOverPanel.SetActive(true);
    }
    
}
