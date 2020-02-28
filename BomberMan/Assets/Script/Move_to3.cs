using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move_to3 : MonoBehaviour
{
    public Move_to m;
    public DeadPlayer Dead;
    //public Animator animator;
    private Transform myTransform;
    public Transform[] points;
    private int destPoint = 0;
    public NavMeshAgent agent;
    Vector3 playerPos;
    Vector3 player2Pos;
    Vector3 player4Pos;
    public GameObject player;
    public GameObject player2;
    public GameObject player4;
    public Transform child;
    float distance;
    float distance2;
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
        player4Pos = player4.transform.position;
        distance4 = Vector3.Distance(this.transform.position, player4Pos);

        if (tracking)
        {
            //追跡の時quitRangerより距離が離れているか
            if (distance > quitRange)
            {
                tracking = false;
            }
            else if(distance2 > quitRange)
            {
                tracking = false;
            }
            else if(distance4 > quitRange)
            {
                tracking = false;
            }

            //Playerを目標とする  
            //agent.destination = playerPos;
            agent.destination = player2Pos;
            //agent.destination = player4Pos;
        }
        else
        {
            //PlayerがtrackingRangeより近づいたら
            if (distance < trackingRange || distance2 < trackingRange || distance4 < trackingRange)
            {
                tracking = true;
                if (m.canDropBombs[1])
                {
                    m.DropBomb();
                    //if (m.bombs[1] == 1) m.canDropBombs[1] = true;
                }

            }

            if (!agent.pathPending && agent.remainingDistance < 1f)
            {
                Move();
               // m.DropBomb();
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
}
