using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kill : MonoBehaviour
{
    public GameObject[] heart;
    UMonster uMonster;
    private void Start()
    {
        for (int i = 0; i < heart.Length; i++)
        {
            heart[i] = GameObject.Find("Image (" + i + ")");
        }
        uMonster = FindObjectOfType<UMonster>();
    }
    private void OnCollisionEnter(Collision Did)
    {
        if(Did.gameObject.tag == "Attack")
        {
            uMonster.blood--;
            for (int i = heart.Length - 1; i >= uMonster.blood; i--)
            {
                if (heart[i] == null)
                    return;
                heart[i].gameObject.SetActive(false);
                Debug.Log("È­¼º");
            }
        }
    }
}
