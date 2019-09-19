using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2 : MonoBehaviour
{

    [Range (1,4)]
    public int PlayerNumber = 1;
    public float moveSpeed = 5.0f;
    public bool canDropBombs = true;
    public bool canMove = true;

    public GameObject bombPrefab;

    private Rigidbody rigidBody;
    private Transform myTransform;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition += new Vector3(0, 0.5f, 0);
        rigidBody = GetComponent<Rigidbody>();
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
    }
    private void UpdateMovement()
    {
        if (!canMove)
            return;
        if (PlayerNumber == 1)
            UpadatePlyer1Movement();
    }

    private void UpadatePlyer1Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += Vector3.forward * moveSpeed * Time.deltaTime; 
            //rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += Vector3.left * moveSpeed * Time.deltaTime;
            //rigidBody.velocity = new Vector3(-moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += Vector3.back * moveSpeed * Time.deltaTime;
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += Vector3.right * moveSpeed * Time.deltaTime;
            //rigidBody.velocity = new Vector3(moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 270, 0);
        }
        if (canDropBombs && Input.GetKeyDown(KeyCode.B))
        {
            DropBomb();
        }
    }

    private void DropBomb()
    {
        if (bombPrefab)
        {
            var pos = new Vector3
                (
                    Mathf.RoundToInt(myTransform.position.x),
                    bombPrefab.transform.position.y+1,
                    Mathf.RoundToInt(myTransform.position.z)
                );
            Instantiate(bombPrefab, pos, bombPrefab.transform.rotation);
        }
    }
}
