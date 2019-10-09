using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move_to4 : MonoBehaviour
{
    public Move_to m;
    public DeadPlayer Dead;
    int PlayerNumber = 4;
    //public Animator animator;
    private Transform myTransform;
    public Transform[] points;
    private int destPoint = 0;
    public NavMeshAgent agent;
    Vector3 playerPos;
    Vector3 player2Pos;
    Vector3 player3Pos;
    public Vector3[] EnemyPos = new Vector3 [3];
    public GameObject player;
    public GameObject player2;
    public GameObject player3;
    public GameObject[] Enemy = new GameObject[3];
    public Transform child;
    float distance;
    float distance2;
    float distance3;
    float trackingRange = 1.5f;
    float quitRange = 1.5f;
    bool tracking = false;


    //public LayerMask LayerMask;//ボムのレイヤーマスク

    // Start is called before the first frame update
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        myTransform = transform;
        Move();



    }

    private void Move()
    {
        //agent.destination = ply.position;
        //地点が何も設定されていない
        if (points.Length == 0)
            return;
        //配列内の次の位置をランダムで取得し目標地点に設定
        destPoint = (Random.Range(0, 91) % points.Length);

        //現在設定されている目標地点に行くように設置
        agent.destination = points[destPoint].position;

        //配列内の次の位置をランダムで取得し目標地点に設定
        //destPoint = (Random.Range(0, 91) % points.Length);

        //animator.SetBool("Walking", true); 
    }

    void FixedUpdate()
    {
        //Playerとのオブジェクトの距離を測る
        playerPos = player.transform.position;
        distance = Vector3.Distance(this.transform.position, playerPos);
        player2Pos = player2.transform.position;
        distance2 = Vector3.Distance(this.transform.position, player2Pos);
        player3Pos = player3.transform.position;
        distance3 = Vector3.Distance(this.transform.position, player3Pos);

        if (tracking)
        {
            //追跡の時quitRangerより距離が離れているか
            if (distance < quitRange)
            {
                agent.destination = playerPos;
                
            }
            
             if (distance2 < quitRange)
            {
                agent.destination = player2Pos;
               
            }
           
            else if (distance3 > quitRange)
            {
                agent.destination = player3Pos;

            }
            else
            tracking = false;

            //Playerを目標とする  



        }
        else
        {
            //PlayerがtrackingRangeより近づいたら
            if (distance < trackingRange )
            {
              
                tracking = true;
                if (m.canDropBombs[2])
                {
                    m.DropBomb();
                    //if (m.bombs[2] == 1) m.canDropBombs[2] = true;
                }
            }
            else if( distance2 < trackingRange)
            {
                
                tracking = true;
                if (m.canDropBombs[2])
                {
                    m.DropBomb();
                    //if (m.bombs[2] == 1) m.canDropBombs[2] = true;
                }
            }
            else if( distance3 < trackingRange)
            {
                tracking = true;
                if (m.canDropBombs[2])
                {
                    m.DropBomb();
                    //if (m.bombs[2] == 1) m.canDropBombs[2] = true;
                }
            }

            if (!agent.pathPending && agent.remainingDistance < 1f)
            {
                Move();
            }

        }

    }

    void Vec3()
    {
        EnemyPos[0] = Enemy[0].transform.position;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Balst"))
        {
            m.dead[2] = true;
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
