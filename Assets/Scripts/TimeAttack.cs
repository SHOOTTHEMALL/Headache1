using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeAttack : MonoBehaviour
{
    public float osu;
    public int bun;

    [SerializeField]
    public Text time;

    private void Update()
    {
        osu += Time.deltaTime;

        time.text = string.Format("{0:D2} : {1:D2}", bun, (int)osu);

        if((int)osu > 59)
        {
            osu = 0;
            bun++;
        }
        if(bun == 7)
        {
            SceneManager.LoadScene("Dead");
        }
    }

    private void OnDestroy()
    {
        _bun = bun;
    }

    public static int _bun; //���� �ٲ� �������� �ʴ´�.
}