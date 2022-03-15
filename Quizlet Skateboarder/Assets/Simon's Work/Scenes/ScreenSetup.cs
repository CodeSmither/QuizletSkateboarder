using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSetup : MonoBehaviour
{
    [SerializeField] List<GameObject> ScreenList = new List<GameObject>();
    List<bool> ListofActivity = new List<bool>();
    public void Awake()
    {

        ScreenList.Add(GameObject.Find("Game Select Panel"));
        ScreenList.Add(GameObject.Find("Options Panel"));
        ScreenList.Add(GameObject.Find("Credits Panel"));
        ScreenList.Add(GameObject.Find("Tutorial Panel"));
        ScreenList.Add(GameObject.Find("Songs Panel"));
        foreach(GameObject Screen in ScreenList)
        {
            ListofActivity.Add(false);
            Screen.SetActive(false);
        }
    }

    public void ActivateandDeactivate(int DesiredScreenNumber)
    {
        ListofActivity[DesiredScreenNumber] = !ListofActivity[DesiredScreenNumber];
        ScreenList[DesiredScreenNumber].SetActive(ListofActivity[DesiredScreenNumber]);
    }

}
