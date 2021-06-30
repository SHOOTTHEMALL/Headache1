using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UMonster : MonoBehaviour
{
    NavMeshAgent enemyAgent;
    Transform playerTrm;

    public LayerMask whatIsGround, whatIsPlayer;
    public Transform shootPos;

    public bool bPlayerInSightRange;
    public bool bPlayerInThrowRange;
    bool bAlreadyAttacked;

    public float sightRange;

    public float ThrowRange;

    public int blood = 3;

    public GameObject[] heart;

    public GameObject projectTile;

    public float timeBetweenAttack;

    public float destroyTime;

    private Animator hue;

    [SerializeField]
    Transform[] wayPoints;

    [SerializeField]
    float remainDistMin = 1f;

    int destPoint = 0;

    float time = 0;

    const float damageTime = 2f;

    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();

        hue = GetComponent<Animator>();

        if (enemyAgent != null)
        {
            enemyAgent.autoBraking = false;

            GoToNextPoint();
        }

        hue.SetBool("run", true);
        hue.SetBool("joy", true);
    }
    void Awake()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        playerTrm = GameObject.Find("Player").transform;
    }

    void Update()
    {
        bPlayerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        bPlayerInThrowRange = Physics.CheckSphere(transform.position, ThrowRange, whatIsPlayer);
        time += Time.deltaTime;

        if (bPlayerInSightRange)
        {
            ChasePlayer();
        }

        if (bPlayerInThrowRange)
        {
            ThrowPlayer();
        }

        if (!enemyAgent.pathPending && enemyAgent.remainingDistance <= remainDistMin)
        {
            GoToNextPoint();
        }

        if(blood <=0)
        {
            SceneManager.LoadScene("Dead");
        }

        int heartCount = 0;
        for (int i = 0; i < heart.Length; i++)
        {
            if (heart[i].activeSelf)
            {
                heartCount++;
            }
        }

        if (heartCount != blood)
        {
            for (int i = heart.Length - 1; i >= blood; i--)
            {
                if (heart[i] == null)
                    return;
                heart[i].gameObject.SetActive(false);
                Debug.Log("화성");
            }
        }
    }

    void GoToNextPoint()
    {
        // 예외처리 안전코드
        if (wayPoints.Length == 0)
        {
            Debug.LogError("최소한 1개 이상의 웨이포인트를 넣으세요");
            enabled = false;
            return;
        }

        enemyAgent.destination = wayPoints[destPoint].position;

        destPoint = (++destPoint) % wayPoints.Length;
    }
    void ChasePlayer()
    {
        enemyAgent.SetDestination(playerTrm.position);
        enemyAgent.destination = playerTrm.position;
    }

    void ThrowPlayer()
    {
        transform.LookAt(playerTrm);
        //Debug.Log("우효1");
        //Debug.Log("우효1");
        if (!bAlreadyAttacked)
        {
            //Debug.Log("우효");
            Rigidbody rb = Instantiate(projectTile, shootPos.position, Quaternion.identity).GetComponent<Rigidbody>();
            Destroy(rb.gameObject, destroyTime);
            rb.AddForce(transform.forward * 100f, ForceMode.Impulse);
            rb.AddForce(transform.up * 0.5f, ForceMode.Impulse);

            bAlreadyAttacked = true;
            Invoke("ResetAttack", timeBetweenAttack);
        }
    }


    void ResetAttack()
    {
        bAlreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, ThrowRange);
    }

    private void OnCollisionStay(Collision Deal)
    {
        if (Deal.gameObject.tag == "Attack" && time >= damageTime)
        {
            time = 0;
            blood--;
            Debug.Log("수원");
            
            //if (Deal.gameObject.tag == "Attack")
            //{
            //    blood--;
            //    Debug.Log("수원");
            //    for (int i = 0; i < heart.Length; i--)
            //    {
            //        heart[i].sprite = null;
            //        Debug.Log("화성");
            //    }
            //}
        }
    }

    private void OnDestroy()
    {
        _blood = blood;
    }

    public static int _blood;
}
