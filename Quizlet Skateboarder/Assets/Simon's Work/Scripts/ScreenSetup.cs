using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSetup : MonoBehaviour
{
    [SerializeField] List<GameObject> ScreenList = new List<GameObject>();
    public void Awake()
    {
        ScreenList.Add(GameObject.Find("Game Select Panel"));
        ScreenList.Add(GameObject.Find("Options Panel"));
        ScreenList.Add(GameObject.Find("Credits Panel"));
        ScreenList.Add(GameObject.Find("Tutorial Panel"));
        ScreenList.Add(GameObject.Find("Songs Panel"));
        foreach(GameObject Screen in ScreenList)
        {
            Screen.SetActive(false);
        }
    }

    public void ActivateandDeactivate(int DesiredScreenNumber)
    {
        foreach(GameObject Screen in ScreenList)
        {
            if(Screen != ScreenList[DesiredScreenNumber])
            {
                Screen.SetActive(false);
            }
            else if(Screen == ScreenList[DesiredScreenNumber])
            {
                if (ScreenList[DesiredScreenNumber].activeSelf) { Screen.SetActive(false); }
                else { Screen.SetActive(true); }
            }
        }
    }
}
