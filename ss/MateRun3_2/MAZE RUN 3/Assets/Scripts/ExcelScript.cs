using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


[System.Serializable]
public class ExcelScript : MonoBehaviour
{
    public TextAsset textAssetData;

    public int id;
    public string names;
    public string sentences;

    

    private void Start()
    {
        ReadCSV();
    }

    void ReadCSV()
    {
        //string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, System.StringSplitOptions.None);

        //for (int i = 0; i < 4; i++)
        //{
        //    Debug.Log(data[i]);
        //}

    }
}
