using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSave : MonoBehaviour
{
    private void Awake()
    {
        if (File.Exists(Application.persistentDataPath + "/score.data"))
        {
            GetComponent<Text>().text = File.ReadAllText(Application.persistentDataPath + "/score.data");
        }
        else
        {
            GetComponent<Text>().text = "";
        }
    }
}