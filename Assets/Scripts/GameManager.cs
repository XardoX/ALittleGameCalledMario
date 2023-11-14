using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Player player;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private UIManager uIManager;

    private int coins;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        Time.timeScale = 1f;
        coins = 0;
        uIManager.DisplayCoinsCount(coins);

    }

    public void RespawnPlayer()
    {
        player.transform.position = spawnPoint.position;
        player.health--;
        if(player.health <= 0)
        {
            ResetLevel();
        }
        Debug.Log(player.health);
        uIManager.SetHearths(player.health);

    }

    public void ResetLevel()
    {
        Time.timeScale = 0f;
        uIManager.ShowGameOverWindow();
    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync("Main");
    }

    public void SetSpawnpoint(Transform spawnPoint)
    {
        this.spawnPoint = spawnPoint;
    }

    public void CollectCoin()
    {
        coins++;
        uIManager.DisplayCoinsCount(coins);
    }
}
