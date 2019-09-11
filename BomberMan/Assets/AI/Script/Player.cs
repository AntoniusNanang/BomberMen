using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Map map;

    Vector3 moveVector;

    Vector3 mapPos;
    Vector3 beforPos;

    Vector3 PlayerPos;

    static public GameObject[] Target = new GameObject[25];
    static public int count = 0;

    [Header("移動側道")]
    public float moveSpeed = 3.0f;

   public GameObject boom;

    enum MoveDirection
    {
        None = -1,
        Back = 0,
        Left = 1,
        Foward = 2,
        Right = 3
    }

    MoveDirection moveDir;
    MoveDirection nextDir;
    void Start()
    {
        
        transform.localPosition += new Vector3(0, 0.5f, 0);
        map = transform.parent.GetComponent<Map>();
        stopMove();
    }

    // Update is called once per frame
    void Update()
    {
        
        InputKey();
        StartMove();
        //IsDirWall();
        if (IsTurn()) Turn();
        UpdateMapPos();
        Boom();
        Debug.Log("mapPos = " + mapPos);
        Debug.Log("boom = " + boom.transform.position);

    }

    void stopMove()
    {
        moveDir = nextDir = MoveDirection.None;
        moveVector = Vector3.zero;
    }
    void StartMove()
    {
        if (nextDir == MoveDirection.None) return;
        if (moveDir != MoveDirection.None) return;

        Turn();
    }
    void InputKey()
    {
        if (Input.GetKey(KeyCode.W))
        { Move(); nextDir = MoveDirection.Foward; }
        else if (Input.GetKey(KeyCode.S))
        { Move(); nextDir = MoveDirection.Back; }
        else if (Input.GetKey(KeyCode.D))
        { Move();nextDir = MoveDirection.Right; }
        else if (Input.GetKey(KeyCode.A))
        { Move();nextDir = MoveDirection.Left; }
    }
    private void Move()
    {
        transform.localPosition += moveVector * moveSpeed * Time.deltaTime;
    }

    bool IsTurn()
    {
        if (nextDir == MoveDirection.None) return false;
        if (moveVector == -DirectionToVector(nextDir)) return true;
        if (moveDir == nextDir) return false;
        return true;
    }

    void Turn()
    {
        moveDir = nextDir;
        moveVector = DirectionToVector(moveDir);
        nextDir = MoveDirection.None;
        transform.eulerAngles = new Vector3(0, (int)moveDir * 90, 0);
    }

    public static GameObject target(GameObject obj)
    {
        count++;
        Target[count - 1] = obj;
        return Target[count - 1];
    }

    void UpdateMapPos()
    {
        beforPos = mapPos;
        mapPos = GetPlayerPos();
    }
    Vector3 GetPlayerPos()
    {
        if(moveDir == MoveDirection.Right || moveDir == MoveDirection.Foward)
        {
            return new Vector3 (
               Mathf.Ceil( transform.position.x),
               Mathf.Ceil( transform.position.y),
               Mathf.Ceil( transform.position.z));
        }
        else if(moveDir == MoveDirection.Left)
        {
            return new Vector3(
              Mathf.Floor(transform.position.x),
              Mathf.Floor(transform.position.y),
              Mathf.Floor(transform.position.z));
        }
        else
        {
            return new Vector3(
               Mathf.Floor(transform.position.x),
               Mathf.Floor(transform.position.y),
               Mathf.Floor(transform.position.z));
        }
    }

    //void IsDirWall()
    //{
    //    for (int i = 0; i < Target.Length; i++)
    //    {
    //        Vector3 subAbs = transform.localPosition - Target[i].transform.localPosition;
    //        subAbs = new Vector3(
    //                      Mathf.Abs(subAbs.x),
    //                      Mathf.Abs(subAbs.y),
    //                      Mathf.Abs(subAbs.z));
    //        Vector3 AddScale = (transform.localScale +
    //                                Target[i].transform.localScale) / 2.0f;
    //        if ((subAbs.x < AddScale.x) &&
    //           (subAbs.y < AddScale.y) &&
    //           (subAbs.z < AddScale.z))
    //        {
    //            Debug.Log("当たり");
    //            stopMove();
    //        }
    //        else
    //        {
    //           //Debug.Log("はずれ");
    //        }
    //    }
       
    //}

    Vector3 DirectionToVector(MoveDirection dir)
    {
        switch (dir)
        {
            case MoveDirection.Left:
                return Vector3.left;
            case MoveDirection.Back:
                return Vector3.back;
            case MoveDirection.Right:
                return Vector3.right;
            case MoveDirection.Foward:
                return Vector3.forward;
            default:
                return Vector3.zero;
        }
    }

    void Boom()
    {
        if (Input.GetKey(KeyCode.B))
        {
            Instantiate(boom, mapPos, Quaternion.identity);
        }
    }
}
