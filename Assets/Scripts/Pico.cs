using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pico : MonoBehaviour
{
    public GameObject panty;
    private void Awake()
    {
        Cursor.visible = true;
    }
    public void GoPico()
    {
         SceneManager.LoadScene("Start");
    }

    public void Pilly()
    {
         Application.Quit();
         Debug.Log("Èñ¸Á");
    }

    public void Blam()
    {
        SceneManager.LoadScene("Play");
    }

    public void Oh()
    {
        panty.gameObject.SetActive(true);
    }

    public void Ho()
    {
        panty.gameObject.SetActive(false);
    }
}
