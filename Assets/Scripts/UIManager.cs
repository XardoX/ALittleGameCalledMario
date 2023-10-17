using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private List<Image> hearths = new();

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
}
