using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSride : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(-0.5f, 0, 0);
        if (transform.position.x < 100f)
        {
            transform.position = new Vector3(700f, 137f, 0);
        }
        // transform.position += Vector3.left * speed * Time.deltaTime;
    }
    // void OnBecameInvisible()
    //{
    //    float width = GetComponent<SpriteRenderer>().bounds.size.x;
    //    transform.position += Vector3.right * width * spriteCount;
    //}
}
