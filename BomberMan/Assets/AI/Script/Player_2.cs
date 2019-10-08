using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2 : MonoBehaviour
{

    [Range (1,4)]
    public int PlayerNumber = 1;
    public float moveSpeed = 5.0f;
    public bool[] canDropBombs = new bool[4];
    public bool canMove = true;

    public Bomb bomb;
    static public int[] maxBomb = new int[4];
    static public int[] bombs = new int[4];
    public int[] PlayerBombPow = new int[4];
    int MaxPow = 6;
    public GameObject bombPrefab;

    public bool dead = false;
    public DeadPlayer DeadPlayer;

    private Rigidbody rigidBody;
    private Transform myTransform;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //transform.localPosition += new Vector3(0, 0.5f, 0);
        rigidBody = GetComponent<Rigidbody>();
        myTransform = transform;

        /*-------ステータス--------*/
        canDropBombs[0] = true; canDropBombs[1] = true; canDropBombs[2] = true; canDropBombs[3] = true;
        bombs[0] = 1; bombs[1] = 1; bombs[2] = 1; bombs[3] = 1;
        maxBomb[0] = 1; maxBomb[1] = 1; maxBomb[2] = 1; maxBomb[3] = 2;
        PlayerBombPow[0] = 3; PlayerBombPow[1] = 3; PlayerBombPow[2] = 3; PlayerBombPow[3] = 3;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
    }
    private void UpdateMovement()
    {
        //animator.SetBool("IsRun", false);
        if (!canMove)
            return;
        if (PlayerNumber == 1)
        {
            UpadatePlyer1Movement();
            BombCount();
        }
    }

    private void UpadatePlyer1Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += Vector3.forward * moveSpeed * Time.deltaTime; 
            //rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 180, 0);
            //animator.SetBool("IsRun", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += Vector3.left * moveSpeed * Time.deltaTime;
            //rigidBody.velocity = new Vector3(-moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 90, 0);
            //animator.SetBool("IsRun", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += Vector3.back * moveSpeed * Time.deltaTime;
            //rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 0, 0);
            //animator.SetBool("IsRun", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += Vector3.right * moveSpeed * Time.deltaTime;
            //rigidBody.velocity = new Vector3(moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 270, 0);
            //animator.SetBool("IsRun", true);
        }
        if (canDropBombs[0] && Input.GetKeyDown(KeyCode.B))
        {
            bomb.Pow = PlayerBombPow[0];
            DropBomb();
            bombs[0]--;
            
        }
    }

    private void DropBomb()
    {
        if (bombPrefab)
        {
            var pos = new Vector3
                (
                    Mathf.RoundToInt(myTransform.position.x),
                    bombPrefab.transform.position.y+0.5f,
                    Mathf.RoundToInt(myTransform.position.z)
                );
            Instantiate(bombPrefab, pos, bombPrefab.transform.rotation);
        }
    }

    //爆弾が0だったら置けない
    void BombCount()
    {
        for(int i = 0; i< bombs.Length; i++)
        {
            if (bombs[i] <= 0)
            {
                canDropBombs[i] = false;
            }
            else
                canDropBombs[i] = true;
        }
    }

    public void BombNum(int bombNum)
    {
        for(int i = 0; i < bombs.Length; i++)
        {
            for(int j = 0; j < maxBomb.Length; j++)
            {
                if (bombs[i] < maxBomb[i])  bombs[i] += bombNum;
                if (bombs[i] >= maxBomb[i]) bombs[i] += 0;
            }
        }
    }
    //プレイヤの当たり判定の処理
    public void OnTriggerEnter(Collider other)
    {
        //爆風にあったとき
        if (other.CompareTag("Balst"))
        {
            dead = true;
            DeadPlayer.PlayerDied(PlayerNumber);
            Destroy(gameObject);
        }
        //アイテムに触れたとき
        if (other.CompareTag("Item"))
        {
            
            switch (PlayerNumber)
            {
                case 1:
                    if (other.GetComponent<Item>().itemType == Item.ItemType.Bomb_UP)
                    {
                        Destroy(other.gameObject);
                        Bomb_UP();
                        bombs[0] += 1;
                    }
                    if(other.GetComponent<Item>().itemType == Item.ItemType.Pow_UP)
                    {
                        Destroy(other.gameObject);
                        PowUP();
                    }
                    break;
            }
        }
    }
    /*-------ステータス処理-------*/
    public void Bomb_UP()
    {
        switch (PlayerNumber)
        {
            case 1:
                maxBomb[0] ++;
                if (maxBomb[0] <= 6) maxBomb[0] += 0;
                Debug.Log(maxBomb[0]);
                break;
            case 2:
                maxBomb[1] += 1;
                if (maxBomb[1] >= 6) maxBomb[1] += 0;
                break;
            case 3:
                maxBomb[2] += 1;
                if (maxBomb[2] >= 6) maxBomb[2] += 0;
                break;
            case 4:
                maxBomb[3] += 1;
                if (maxBomb[3] >= 6) maxBomb[3] += 0;
                break;
            default:
                break;
        }
    }
    public void PowUP()
    {
        switch (PlayerNumber)
        {
            case 1:
                PlayerBombPow[0] += 1;
                if (PlayerBombPow[0] > MaxPow) PlayerBombPow[0] += 0;
                break;
            case 2:
                PlayerBombPow[1] += 1;
                if (PlayerBombPow[1] > MaxPow) PlayerBombPow[1] += 0;
                break;
            case 3:
                PlayerBombPow[2] += 1;
                if (PlayerBombPow[2] > MaxPow) PlayerBombPow[2] += 0;
                break;
            case 4:
                PlayerBombPow[3] += 1;
                if (PlayerBombPow[3] > MaxPow) PlayerBombPow[3] += 0;
                break;
            default:
                break;
        }
    }
}
