using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;
using UnityEngine.EventSystems;
using JetBrains.Annotations;
using DG.Tweening;

public class Player : MonoBehaviour
{
    private CharacterController playerController;
    public Camera fpsCam;
    private Animator run;

    float MoveSpeed;
    float rotSpeed;
    float currentRot;

    public LayerMask whatIsGround;

    private Vector3 moveDirection = Vector3.zero;

    bool isHide = false;

    bool canMoveInput = true;

    [SerializeField]
    private float gravity = 10;

    float time = 0;

    const float sayu = 20f;

    public GameObject[] Chick;
    //public GameObject Chick1;
    //public GameObject Chick2;
    //public GameObject Chick3;
    //public GameObject Chick4;

    public GameObject[] Seve;

    public int clear = 0;

    private void Awake()
    {
        playerController = GetComponent<CharacterController>();

        Cursor.visible = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        MoveSpeed = 5.0f;
        rotSpeed = 3.0f;
        currentRot = 0f;

        run = GetComponentInChildren<Animator>();

        run.SetBool("IsRun", false);

    }

    // Update is called once per frame
    void Update()
    {
        if (canMoveInput)
        {
            PlayerMove();
        }
        RotCtrl();

       

        if(isHide)
        {
            playerController.enabled = false;
            time += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space) || time > sayu)
            {
                playerController.enabled = true;
                isHide = false;
                time = 0;
            }
            //Debug.Log("키킼 냉마불");
        } 

        if (playerController.isGrounded == false)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if(clear >= 9)
        {
            SceneManager.LoadScene("Done");
        }
    }

    void PlayerMove()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * MoveSpeed;
        float zSpeed = zInput * MoveSpeed;

        playerController.Move(transform.forward * zSpeed * Time.deltaTime + transform.right * xSpeed * Time.deltaTime);
        playerController.Move(moveDirection * Time.deltaTime);
        run.SetBool("IsRun", true);
    }

    void RotCtrl()
    {
        float rotX = Input.GetAxis("Mouse Y") * rotSpeed;
        float rotY = Input.GetAxis("Mouse X") * rotSpeed;

        // 마우스 반전
        currentRot -= rotX;

        // 마우스가 특정 각도를 넘어가지 않게 예외처리
        //currentRot = Mathf.Clamp(currentRot, -80f, 80f);

        // Camera는 Player의 자식이므로 플레이어의 Y축 회전은 Camera에게도 똑같이 적용됨
        this.transform.localRotation *= Quaternion.Euler(0, rotY, 0);
        // Camera의 transform 컴포넌트의 로컬로테이션의 오일러각에 
        // 현재X축 로테이션을 나타내는 오일러각을 할당해준다.
        fpsCam.transform.localEulerAngles = new Vector3(currentRot, 0f, 0f);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Seve")
        {
            isHide = true;
            hit.collider.gameObject.SetActive(false);
            Debug.Log("틱톡젤리");
        }

        if (hit.gameObject.tag == "Chick")
        {
            clear++;
            Debug.Log(clear);
            Destroy(Chick[0].gameObject);
        }
        else if (hit.gameObject.tag == "Chickk")
        {
            clear++;
            Debug.Log(clear);
            Destroy(Chick[1].gameObject);
        }
        else if (hit.gameObject.tag == "Chickkk")
        {
            clear++;
            Debug.Log(clear);
            Destroy(Chick[2].gameObject);
        }
        else if (hit.gameObject.tag == "Chickkkk")
        {
            clear++;
            Debug.Log(clear);
            Destroy(Chick[3].gameObject);
        }
        else if (hit.gameObject.tag == "Chickkkkk")
        {
            clear++;
            Debug.Log(clear);
            Destroy(Chick[4].gameObject);
        }

        if(hit.gameObject.tag == "LostTime")
        {
            canMoveInput = false;
            transform.DOMoveZ(0.5f,1).OnComplete(() =>
            {
                canMoveInput = true;
            });
        }
        if(hit.gameObject.tag == "Memory")
        {
            canMoveInput = false;
            transform.DOMoveZ(-15, 1).OnComplete(() =>
            {
                canMoveInput = true;
            });
        }
        if (hit.gameObject.tag == "You")
        {
            canMoveInput = false;
            transform.DOMoveZ(20, 1).OnComplete(() =>
            {
                canMoveInput = true;
            });
        }
        if (hit.gameObject.tag == "Right")
        {
            canMoveInput = false;
            transform.DOMoveZ(34, 1).OnComplete(() =>
            {
                canMoveInput = true;
            });
        }
        if (hit.gameObject.tag == "Right")
        {
            canMoveInput = false;
            transform.DOMoveZ(34, 1).OnComplete(() =>
            {
                canMoveInput = true;
            });
        }
        if (hit.gameObject.tag == "Night")
        {
            canMoveInput = false;
            transform.DOMoveX(50, 1).OnComplete(() =>
            {
                canMoveInput = true;
            });
        }
        if (hit.gameObject.tag == "Picnic")
        {
            canMoveInput = false;
            transform.DOMoveX(37, 1).OnComplete(() =>
            {
                canMoveInput = true;
            });
        }
        if (hit.gameObject.tag == "Of")
        {
            canMoveInput = false;
            transform.DOMoveX(-41, 1).OnComplete(() =>
            {
                canMoveInput = true;
            });
        }
        if (hit.gameObject.tag == "Off")
        {
            canMoveInput = false;
            transform.DOMoveX(-27, 1).OnComplete(() =>
            {
                canMoveInput = true;
            });
        }
        if (hit.gameObject.tag == "Nogada")
        {
            canMoveInput = false;
            transform.DOMoveZ(-20, 1).OnComplete(() =>
            {
                canMoveInput = true;
            });
        }
        if (hit.gameObject.tag == "Yabal")
        {
            canMoveInput = false;
            transform.DOMoveZ(22, 1).OnComplete(() =>
            {
                canMoveInput = true;
            });
        }
        if (hit.gameObject.tag == "No")
        {
            canMoveInput = false;
            transform.DOMoveX(-6, 1).OnComplete(() =>
            {
                canMoveInput = true;
            });
        }
        if (hit.gameObject.tag == "Roads")
        {
            canMoveInput = false;
            transform.DOMoveX(-34, 1).OnComplete(() =>
            {
                canMoveInput = true;
            });
        }
        if (hit.gameObject.tag == "Hand")
        {
            canMoveInput = false;
            transform.DOMoveX(32, 1).OnComplete(() =>
            {
                canMoveInput = true;
            });
        }
        if (hit.gameObject.tag == "Foot")
        {
            canMoveInput = false;
            transform.DOMoveX(46, 1).OnComplete(() =>
            {
                canMoveInput = true;
            });
        }
        if (hit.gameObject.tag == "Black")
        {
            canMoveInput = false;
            transform.DOMoveZ(26, 1).OnComplete(() =>
            {
                canMoveInput = true;
            });
        }
        if (hit.gameObject.tag == "White")
        {
            canMoveInput = false;
            transform.DOMoveZ(60, 1).OnComplete(() =>
            {
                canMoveInput = true;
            });
        }
        if (hit.gameObject.tag == "Zero")
        {
            canMoveInput = false;
            transform.DOMoveX(-34, 1).OnComplete(() =>
            {
                canMoveInput = true;
            });
        }
        if (hit.gameObject.tag == "Two")
        {
            canMoveInput = false;
            transform.DOMoveX(-17, 1).OnComplete(() =>
            {
                canMoveInput = true;
            });
        }
    }
}