using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move_to : MonoBehaviour
{
    public Transform ply;
    public Player_2 p;
    public GameObject bombPrefab;
    private Transform myTransform;
    public int bombs = 2;
    public bool canDropBombs = true;
    public Bomb bomb;
    int a;//bombの値を格納
    public LayerMask LayerMask;//ボムのレイヤーマスク
    public LayerMask lay;//プレイヤーのレイヤーマスク
    private Animator animator;

    const float BOMB_SET_INTERVAL = 1.0f;
    float bombSetCnt = 0.0f;

   
    // Start is called before the first frame updat
    void Start()
    {
       
        a = bomb.Pow;
        myTransform = transform;
        //p = p_0.GetComponent<Player_2>();
        //animator = myTransform.Find("PlayerModel").GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Move();
        Ray();
        if(a < bomb.Pow)
        {
            a = bomb.Pow;
        }
        BombCount();
    }
    
    private void Move()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = ply.position;
        //animator.SetBool("Walking", true);
    }
    private void bom_A()
    {
        Debug.Log("生成");
            if (bombPrefab)
            { //Check if bomb prefab is assigned first
                var pos = new Vector3
                    (
                        Mathf.RoundToInt(myTransform.position.x),bombPrefab.transform.position.y+1f,Mathf.RoundToInt(myTransform.position.z) );
                Instantiate
                    (
                    bombPrefab,
                    pos,
                    bombPrefab.transform.rotation
                    );          
            }
    }
    void BombCount()
    {
        if (bombs <= 0)
        {
            canDropBombs = false;
        }
        else
            canDropBombs = true;
    }
    //爆発したときにボムを増やす
    public void BombNu(int bombNu)
    {
        bombs += bombNu;
        if(bombs >= 2)
        {
            bombs += 0;
        }
    }
    //ボムから逃げる処理
    private void escape()
    {
    }
    void Ray()
    {      
       //rayの作成
       Ray ray_up= new Ray(transform.position, Vector3.forward);
        Ray ray_down = new Ray(transform.position,Vector3.back);
        Ray ray_right = new Ray(transform.position,Vector3.right);
        Ray ray_left = new Ray(transform.position,Vector3.left);

        //rayが当たった物体の情報を入れる箱
        RaycastHit hit;
        
        float distance = 2;//rayが飛ばせる範囲(ボム用)
        float disply = 2.5f;//rayが飛ばせる範囲(プレイヤー用)
        float breblok = 1f;//rayが飛ばせる範囲(破壊可能ブロック)
        //rayの可視化
        Debug.DrawLine(ray_up.origin,ray_up.origin + ray_up.direction * distance, Color.red);
        Debug.DrawLine(ray_down.origin,ray_down.origin + ray_down.direction * distance, Color.blue);
        Debug.DrawLine(ray_right.origin,ray_right.origin + ray_right.direction * distance, Color.yellow);
        Debug.DrawLine(ray_left.origin,ray_left.origin + ray_left.direction * distance, Color.gray);
        if(Physics.Raycast(ray_up,out hit,distance,LayerMask))//ボムが前にあるときの処理
        {
        }
        if (Physics.Raycast(ray_down,out hit, distance,LayerMask))//ボムが下にあるときの処理
        {
            //Transform ply2 = this.transform;
            //Vector3 pos = ply2.position;
            //pos.x -= a;
            //ply2.position = pos;
        }
        if (Physics.Raycast(ray_right, out hit,distance,LayerMask))//ボムが右にあるときの処理
        {
            //Transform ply2 = this.transform;
            //Vector3 pos = ply2.position;
            //pos.z += a;
            //ply2.position = pos;

        }
        if (Physics.Raycast(ray_left, out hit,distance,LayerMask))//ボムが左にあるときの処理
        {
            //Transform ply2 = this.transform;
            //Vector3 pos = ply2.position;
            //pos.z -= a;
            //ply2.position = pos;
        }

        // ボムの再設置待機時間が終わってなかったら関数終了
        bombSetCnt += Time.deltaTime;
        if (bombSetCnt <= BOMB_SET_INTERVAL) return;

        if(Physics.Raycast(ray_up,out hit, disply, lay))//プレイヤーが上にいるとき
        {
            Debug.Log("上");
            if (canDropBombs)
            {
                bom_A();
                bombs--;
                
            }
        }
        if (Physics.Raycast(ray_down, out hit, disply, lay))//プレイヤーが下にいるとき
        {
            Debug.Log("下");
            if (canDropBombs)
            {
                bom_A();
                bombs--;
                

            }
        }
        if (Physics.Raycast(ray_right, out hit, disply, lay))//プレイヤーが右にいるとき
        {
            Debug.Log("右");
            if (canDropBombs)
            {
                bom_A();
                bombs--;
                

            }

        }
        if (Physics.Raycast(ray_left, out hit, disply, lay))//プレイヤーが左にいるとき
        {
            Debug.Log("左");
            if (canDropBombs)
            {
                bom_A();
                bombs--;
                

            }
        }
        bombSetCnt = 0.0f;// カウント初期化

    }
}
    

