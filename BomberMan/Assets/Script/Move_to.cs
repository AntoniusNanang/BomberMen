using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move_to : MonoBehaviour
{
    
    //public Player_2 p;
    public GameObject bombPrefab;
    public int[] bombs = new int [3];
    public bool[] canDropBombs = new bool [3];
    public Bomb bomb;
    int a;//bombの値を格納
    public LayerMask LayerMask;//ボムのレイヤーマスク
    public LayerMask lay;//プレイヤーのレイヤーマスク
    public LayerMask la; //破壊可能ブロックのレイヤーマスク
    private Animator animator;
    int b  ;//全方向にボムあるかの変数
    const float BOMB_SET_INTERVAL = 1.0f;
    float bombSetCnt = 0.0f;
    [Range(2, 4)]
    public int PlayerNumber;
    static public bool[] dead = new bool[3];
    public DeadPlayer DeadPlayer;

    // Start is called before the first frame updat
    void Start()
    {
        if(PlayerNumber == 2)
        {
            Debug.Log(transform.position);
        }
        else if(PlayerNumber == 4)
        {
            Debug.Log(transform.position);
        }
        a = bomb.Pow;
       
        //p = p_0.GetComponent<Player_2>();
        //animator = myTransform.Find("PlayerModel").GetComponent<Animator>();

        //ステータス
        bombs[0] = 1; bombs[1] = 1; bombs [2] = 1;
        canDropBombs[0] = true; canDropBombs[1] = true; canDropBombs[2] = true;
        dead[0] = false; dead[1] = false; dead[2] = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {     
        
        //Ray();
        //if(a < bomb.Pow)
        //{
        //    a = bomb.Pow;
        //}
        BombCount();
    }


   
    void BombCount()
    {
        for(int i = 0; i < canDropBombs.Length; i++)
        {
            if (bombs[i] <= 0)
            {
                canDropBombs[i] = false;
            }
            else
                canDropBombs[i] = true;
        }
        
    }
    //爆発したときにボムを増やす
    public void BombNu(int bombNu)
    {
        
        if (bombs[0] <= 0)
        {
            bombs[0] += bombNu;
            if (bombs[0] == 1)
            {
                bombs[0] += 0;
            }

        }
        if (bombs[1] <= 0)
        {
            bombs[1] += bombNu;
            if (bombs[1] == 1)
            {
                bombs[1] += 0;
            }

        }
        if (bombs[2] <= 0)
        {
            bombs[2] += bombNu;
            if (bombs[2] == 1)
            {
                bombs[2] += 0;
            }

        }

        //for (int i = 0; i < bombs.Length; i++)
        //{
        //    bombs[i] += bombNu;
        //    if (bombs[i] >= 1)
        //    {
        //        bombs[i] += 0;
        //    }
        //}

    }
    public void DropBomb()
    {
        if (bombPrefab)
        {
            var pos = new Vector3
                (
                    Mathf.RoundToInt(transform.position.x),
                    bombPrefab.transform.position.y + 0.5f,
                    Mathf.RoundToInt(transform.position.z)
                );
            Instantiate(bombPrefab, pos, bombPrefab.transform.rotation);

        }
        bombs[PlayerNumber - 2]--;
    }
    //public void Ray()
    //{      
    //   //rayの作成
    //   Ray ray_up= new Ray(transform.position, Vector3.forward);
    //    Ray ray_down = new Ray(transform.position,Vector3.back);
    //    Ray ray_right = new Ray(transform.position,Vector3.right);
    //    Ray ray_left = new Ray(transform.position,Vector3.left);

    //    //rayが当たった物体の情報を入れる箱
    //    RaycastHit hit;
        
    //    float distance = 2;//rayが飛ばせる範囲(ボム用)
    //    float disply = 2.5f;//rayが飛ばせる範囲(プレイヤー用)
    //    //float breblok = 1f;//rayが飛ばせる範囲(破壊可能ブロック)  
    //    //rayの可視化
    //    Debug.DrawLine(ray_up.origin,ray_up.origin + ray_up.direction * distance, Color.red);
    //    Debug.DrawLine(ray_down.origin,ray_down.origin + ray_down.direction * distance, Color.blue);
    //    Debug.DrawLine(ray_right.origin,ray_right.origin + ray_right.direction * distance, Color.yellow);
    //    Debug.DrawLine(ray_left.origin,ray_left.origin + ray_left.direction * distance, Color.gray);

    //    // ボムの再設置待機時間が終わってなかったら関数終了
    //    bombSetCnt += Time.deltaTime;
    //    if (bombSetCnt <= BOMB_SET_INTERVAL) return;

    //    //if (Physics.Raycast(ray_up, out hit, breblok, la))//破壊可能ブロックが前にあるときの処理
    //    //{

    //    //    if (canDropBombs[PlayerNumber - 2])
    //    //    {

    //    //        DropBomb();
    //    //        bombs[PlayerNumber - 2]--;
    //    //    }
    //    //}
    //    //if (Physics.Raycast(ray_down, out hit, breblok, la))//破壊可能ブロックが下にあるときの処理
    //    //{
    //    //    if (canDropBombs[PlayerNumber - 2])
    //    //    {

    //    //        DropBomb();
    //    //        bombs[PlayerNumber - 2]--;
    //    //    }
    //    //}
    //    //if (Physics.Raycast(ray_right, out hit, breblok, la))//破壊可能ブロックが右にあるときの処理
    //    //{
    //    //    if (canDropBombs[PlayerNumber - 2])
    //    //    {

    //    //        DropBomb();
    //    //        bombs[PlayerNumber - 2]--;
    //    //    }

    //    //}
    //    //if (Physics.Raycast(ray_left, out hit, breblok, la))//破壊可能ブロックが左にあるときの処理
    //    //{
    //    //    if (canDropBombs[PlayerNumber - 2])
    //    //    {

    //    //        DropBomb();
    //    //        bombs[PlayerNumber - 2]--;
    //    //    }
    //    //}


    //    if (Physics.Raycast(ray_up, out hit, disply, lay))//プレイヤーが上にいるとき
    //    {

    //        if (canDropBombs[PlayerNumber - 2])
    //        {
    //            DropBomb();
    //            bombs[PlayerNumber - 2]--;
    //        }
    //    }
    //    if (Physics.Raycast(ray_down, out hit, disply, lay))//プレイヤーが下にいるとき
    //    {
    //        if (canDropBombs[PlayerNumber - 2])
    //        {
    //            DropBomb();
    //            bombs[PlayerNumber - 2]--;
    //        }
    //    }
    //    if (Physics.Raycast(ray_right, out hit, disply, lay))//プレイヤーが右にいるとき
    //    {
    //        if (canDropBombs[PlayerNumber - 2])
    //        {
    //            DropBomb();
    //            bombs[PlayerNumber - 2]--;
    //        }

    //    }
    //    if (Physics.Raycast(ray_left, out hit, disply, lay))//プレイヤーが左にいるとき
    //    {
    //        if (canDropBombs[PlayerNumber - 2])
    //        {
    //            DropBomb();
    //            bombs[PlayerNumber - 2]--;
    //        }
    //    }
    //    bombSetCnt = 0.0f;// カウント初期化
    //    sum(ray_up, ray_down, ray_right, ray_left, hit, distance);
    //}
    //void sum(Ray ray_up, Ray ray_down, Ray ray_right, Ray ray_left, RaycastHit hit, float distance)
    //{
    //    if (!Physics.Raycast(ray_up, out hit, distance, LayerMask)
    //        && !Physics.Raycast(ray_down, out hit, distance, LayerMask)
    //        && !Physics.Raycast(ray_right, out hit, distance, LayerMask)
    //        && !!Physics.Raycast(ray_left, out hit, distance, LayerMask))
    //    {
    //        b = 0;
    //    }
    //    else b = 1;
    //}
    public void des()
    {
        if (PlayerNumber == 2)
        {

            if (dead[PlayerNumber - 2])
            {
                DeadPlayer.PlayerDied(PlayerNumber);
            } 
            dead[PlayerNumber - 2] = true;
            gameObject.SetActive(false);
        }
        else if (PlayerNumber == 3)
        {
            if (dead[PlayerNumber - 2])
                DeadPlayer.PlayerDied(PlayerNumber);
            dead[PlayerNumber - 2] = true;
            gameObject.SetActive(false);
        }
        else if (PlayerNumber == 4)
        {
            if (dead[PlayerNumber - 2])
            {
                DeadPlayer.PlayerDied(PlayerNumber);
            }
            dead[PlayerNumber - 2] = true;
            gameObject.SetActive(false);
        }
    }

   
}
    

