using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move_to02 : MonoBehaviour
{
    public Move_to m;
    public DeadPlayer Dead;
    //public Animator animator;
    private Transform myTransform;
    public Transform[] points;
    private int destPoint = 0;
    public NavMeshAgent agent;
    Vector3 playerPos;
    Vector3 player3Pos;
    Vector3 player4Pos;
    public GameObject player;
    public GameObject player3;
    public GameObject player4;
    public Transform child;
    float distance;
    float distance3;
    float distance4;
    float trackingRange = 2f;
    float quitRange = 2f;
    bool tracking = false;
    //public LayerMask LayerMask;//ボムのレイヤーマスク

    // Start is called before the first frame update
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        myTransform = transform;
        Move();

        //player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Move()
    {
        //agent.destination = ply.position;
        //地点が何も設定されていない
        if (points.Length == 0)
            return;

        //現在設定されている目標地点に行くように設置
       // agent.destination = points[destPoint].position;

        //配列内の次の位置をランダムで取得し目標地点に設定
        destPoint = (Random.Range(0, 91) % points.Length);

        //現在設定されている目標地点に行くように設置
        agent.destination = points[destPoint].position;
           
        //animator.SetBool("Walking", true); 
    }
    
    //void OnTriggerEnter(Collider collider)
    //{
    //    Ray ray_up = new Ray(transform.position, Vector3.forward);
    //    Ray ray_down = new Ray(transform.position, Vector3.back);
    //    Ray ray_right = new Ray(transform.position, Vector3.right);
    //    Ray ray_left = new Ray(transform.position, Vector3.left);

    //    //rayが当たった物体の情報を入れる箱
    //    RaycastHit hit;

    //    float distance = 2;//rayが飛ばせる範囲(ボム用)
    //    if (collider.gameObject.tag == "run")
    //    {
    //    }
           
    //    if(collider.gameObject.tag == "Boom")
    //    {
    //        Debug.Log(child.position);
    //        //Debug.Log("aa");
    //        if (Physics.Raycast(ray_up, out hit, distance, LayerMask))//うえ
    //        {
                
    //            //n.destPoint = n.points[i + 3];
    //            destPoint = (int)gameObject.transform.position.z - 2;
    //            //n.agent.destination = n.points[n.destPoint].position;
    //        }
    //        if (Physics.Raycast(ray_down, out hit, distance, LayerMask))//下
    //        {
    //            destPoint = (int)gameObject.transform.position.z + 2;
    //            //n.agent.destination = n.points[n.destPoint].position;
    //        }
    //        if (Physics.Raycast(ray_right, out hit, distance, LayerMask))//右
    //        {
    //            destPoint = (int)gameObject.transform.position.x - 2;
    //            //n.agent.destination = n.points[n.destPoint].position;
    //        }
    //        if (Physics.Raycast(ray_left, out hit, distance, LayerMask))//左
    //        {
    //            destPoint = (int)gameObject.transform.position.x + 2;
    //            //n.agent.destination = n.points[n.destPoint].position;
    //        }
    //    }
        

    //}

    // Update is called once per frame
    void FixedUpdate()
    {
        //Playerとのオブジェクトの距離を測る
        playerPos = player.transform.position;
        distance = Vector3.Distance(this.transform.position, playerPos);
        player3Pos = player3.transform.position;
        distance3 = Vector3.Distance(this.transform.position, player3Pos);
        player4Pos = player4.transform.position;
        distance4 = Vector3.Distance(this.transform.position, player4Pos);


        if (tracking)
        {
            //追跡の時quitRangerより距離が離れているか
            if(distance > quitRange /*|| distance3 > quitRange || distance4 >quitRange*/)
            {
                tracking = false;
            }

            //Playerを目標とする  
            agent.destination = playerPos;
            //agent.destination = player3Pos;
            //agent.destination = player4Pos;
        }
        else
        {
            //PlayerがtrackingRangeより近づいたら
            if (distance < trackingRange || distance3 < trackingRange || distance4 < trackingRange)
            {
                tracking = true;
                if (m.canDropBombs[0])
                {
                    m.DropBomb();
                    //if (m.bombs[0] == 1) m.canDropBombs[0] = true;
                }
            }
                
            if (!agent.pathPending && agent.remainingDistance < 1f)
            {
                Move();
            }
               
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Balst"))
        {
            m.dead[1] = true;
            Dead.PlayerDied(m.PlayerNumber);
            gameObject.SetActive(false);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, trackingRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, quitRange);
    }
}
