using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;
using DictonaryConverter;

public class DictonaryTest : MonoBehaviour
{
    DictonaryStorage dictonaryStorage;
    [SerializeField]string DictonaryFile;
    private void Start()
    {
        dictonaryStorage = new DictonaryStorage(DictonaryFile);
        dictonaryStorage.OrginizeDictionary();
        Debug.Log(dictonaryStorage.ValuesArray[0, 0]);
        Debug.Log(dictonaryStorage.ValuesArray[1, 0]);
        Debug.Log(dictonaryStorage.ValuesArray[0, 1]);
        Debug.Log(dictonaryStorage.ValuesArray[1, 1]);
    }
}
