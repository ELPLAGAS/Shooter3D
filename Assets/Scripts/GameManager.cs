using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text txtTotalEnemiesKilled;
    public int totalKills;
    public GameObject enemyContainer;

    float timer;
    public Text txtTimer;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        totalKills = enemyContainer.GetComponentsInChildren<EnemyController>().Length;
        txtTotalEnemiesKilled.text = "Total Enemies: " + totalKills.ToString();
        timer = 0.0f;
        txtTimer.text = "Time; " + timer.ToString("n2");
    }
    public void AddEnemyKill()
    {
        totalKills--;
        txtTotalEnemiesKilled.text = "Total Enemies: " + totalKills.ToString();
        if(totalKills <= 0)
        {
            FinGame(true);
        }
    }

    private void Update()
    {
        timer +=Time.deltaTime;
        txtTimer.text = "Time; " + timer.ToString("n2");

        if (Input.GetKeyDown(KeyCode.Return))
        {
            staticValues.winner = -1;
            SceneManager.LoadScene(0);
            
        }
    }
   
    public void FinGame(bool isWin)
    {
        if(isWin == true)
        {
            Debug.Log("Has Ganado");
            staticValues.winner = 1;
        }
        else
        {
            Debug.Log("Has Perdido");
            staticValues.winner = 0;
        }

        SceneManager.LoadScene(0);

    }
}