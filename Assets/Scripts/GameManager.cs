using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject endUI;

    public Text title;

    public static GameManager Instance;

    private EnemySpawner enemySpawner;

    void Awake()
    {
        Instance = this;
        enemySpawner = GetComponent<EnemySpawner>();
    }

    public void Win()
    {
        title.text = "WIN!";
        endUI.SetActive(true);
    }

    public void Failed()
    {
        enemySpawner.Stop();
        title.text = "Failed!";
        endUI.SetActive(true);
    }
}
