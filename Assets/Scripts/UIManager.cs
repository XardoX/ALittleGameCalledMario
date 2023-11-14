using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private List<Image> hearths = new();

    [SerializeField]
    private TextMeshProUGUI coinCountText;

    [SerializeField]
    private CanvasGroup gameoverWindow;

    public void SetHearths(int count)
    {
        foreach(var hearth in hearths)
        {
            hearth.gameObject.SetActive(false);
        }

        for(int i = 0; i < hearths.Count && i < count; i++)
        {

            hearths[i].gameObject.SetActive(true);
        }
    }

    public void DisplayCoinsCount(int count)
    {
        coinCountText.text = "x " + count.ToString("00");
    }

    public void ShowGameOverWindow()
    {
        gameoverWindow.DOFade(1f, 0.5f).SetUpdate(true);
    }

    public void RestartGame() => GameManager.Instance.RestartGame();
}
