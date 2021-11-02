using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class Jogador2 : MonoBehaviour
{
    public static bool j2win = false;

    private int A = 0;
    private int damage = 5;
    private CharacterController controller;
    private string check = "Z";

    public float speed;
    public float gravity;
    public float rspeed;

    private float rot;
    private Vector3 moveDirection;
    private int vida = 170;

    protected Rigidbody Rigidbody;

    public AudioSource Run;
    public AudioSource Upp;
    public AudioSource Die;

    PhotonView view;

    // Start is called before the first frame update
    public void Awake()
    {
        view = GetComponent<PhotonView>();
        vida = GameManager.twoHealth;
    }

    public void Start()
    {

        Rigidbody = GetComponent<Rigidbody>();
        if (view.IsMine)
        {
            controller = GetComponent<CharacterController>();
            this.enabled = true;
        }
        else
        {
            this.enabled = false; //disable the movescript if photonview is not mine.
            Destroy(GetComponent<CharacterController>());
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            Move();
            view.RPC("RPC_playerK", RpcTarget.All, GameManager.twoScore, GameManager.twoHealth);
            
        }
            
       

    }
    void Move()
    {
        if (A == 0)
        {

            if (Input.GetKey(KeyCode.W))
            {
                moveDirection = Vector3.forward * speed;
                Run.Play();
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                moveDirection = Vector3.zero;
            }
            if (Input.GetKey(KeyCode.S))
            {
                moveDirection = Vector3.forward * -speed;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                moveDirection = Vector3.zero;
            }
        }

        rot += Input.GetAxis("Horizontal") * rspeed * Time.deltaTime * 2;
        transform.eulerAngles = new Vector3(0, rot, 0);
        moveDirection.y -= gravity * Time.deltaTime;
        moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection * Time.deltaTime);
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ponto")
        {
            
                check = "PP";
                Upp.Play();


        }
        if (col.gameObject.tag == "Finish")
        {
            
                check = "FF";
                Die.Play();

        }
        if (col.gameObject.tag == "Player")
        {
            
                check = "JJ";
                Die.Play();

        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (view.IsMine)
        {
            controller.transform.position = new Vector3(28, 9, 52);
            Physics.SyncTransforms();
            A = 0;
            Die.Play();
            GameManager.twoHealth = GameManager.twoHealth - damage;
        }
    }

    [PunRPC]
    void RPC_playerK(int twoScore,int twoHealth)
    {
        if (check == "PP")
        {
            GameManager.twoScore++; GameManager.twoScore++; GameManager.twoScore++;
            GameManager.twoScore++; GameManager.twoScore++;
            check = "Z";
        }
        else if (check == "FF")
        {
                GameManager.twoHealth = GameManager.twoHealth - damage;
                check = "Z";
        }
        else if (check == "JJ")
        {
            GameManager.twoHealth = GameManager.twoHealth - damage;
            check = "Z";
        }
        if (GameManager.twoHealth <= 0)
        {
            Jogador.j1win = true;
        }
        if (GameManager.twoScore >= 50)
        {
            j2win = true;
        }
        if (check == "P")
        {
            GameManager.oneScore++; GameManager.oneScore++; GameManager.oneScore++;
            GameManager.oneScore++; GameManager.oneScore++;
            check = "Z";
        }
        else if (check == "F")
        {
            GameManager.oneHealth = GameManager.oneHealth - damage;
            check = "Z";
        }
        else if (check == "J")
        {
            GameManager.oneHealth = GameManager.oneHealth - damage;
            check = "Z";
        }
        if (GameManager.oneHealth <= 0)
        {
            j2win = true;
        }
        if (GameManager.oneScore >= 100)
        {
            Jogador.j1win = true;
        }

    }


}
