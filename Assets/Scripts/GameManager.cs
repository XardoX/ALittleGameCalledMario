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
        SceneManager.LoadSceneAsync("Main");
    }

    public void SetSpawnpoint(Transform spawnPoint)
    {
        this.spawnPoint = spawnPoint;
    }
}
