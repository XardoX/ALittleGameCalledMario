using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Button quitButton;

    private void Awake()
    {
        quitButton.onClick.AddListener(Quit);
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Main");
    }

    public void Quit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}
