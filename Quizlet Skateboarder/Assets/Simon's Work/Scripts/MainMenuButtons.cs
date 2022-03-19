using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField]public int ButtonID;
    private ScreenSetup screenSetup;

    public void Awake()
    {
        screenSetup = GameObject.Find("Canvas").GetComponent<ScreenSetup>();
    }

    public void Button()
    {
        screenSetup.ActivateandDeactivate(ButtonID);
    }
}
