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
        uMonster = FindObjectOfType<UMonster>();
    }
    private void OnCollisionEnter(Collision Did)
    {
        if(Did.gameObject.tag == "Attack")
        {
            uMonster.blood--;
        }
    }
}
