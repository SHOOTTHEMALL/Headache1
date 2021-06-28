using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject text;
    public GameObject text1;
    public GameObject text2;

    void Update()
    {
        if(TimeAttack._bun <= 3 && UMonster._blood >= 3)
        {
            text.gameObject.SetActive(true);
            File.WriteAllText(Application.persistentDataPath + "/score.data", "Ira");
        }
        else if(TimeAttack._bun <= 4)
        {
            text1.gameObject.SetActive(true);

            if (File.Exists(Application.persistentDataPath + "/score.data"))
            {
                if (int.Parse(File.ReadAllText(Application.persistentDataPath + "/score.data")) == 3)
                {
                    File.WriteAllText(Application.persistentDataPath + "/score.data", "Luxuria");
                }
            }
            else
            {
                File.WriteAllText(Application.persistentDataPath + "/score.data", "Luxuria");
            }
        }
        else if(TimeAttack._bun <= 6)
        {
            text2.gameObject.SetActive(true);
            if (!File.Exists(Application.persistentDataPath + "/score.data"))
            {
                File.WriteAllText(Application.persistentDataPath + "/score.data", "Pigritia");
            }
        }
    }
}
