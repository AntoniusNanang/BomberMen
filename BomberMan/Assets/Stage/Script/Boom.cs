using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    Boom_Blast ColliderTriggerParent;//親のコライダー
    void Start()
    {
        GameObject objColliderTriggerParent = gameObject.transform.parent.gameObject;
        ColliderTriggerParent = objColliderTriggerParent.GetComponent<Boom_Blast>();
    }

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.gameObject.tag);
        if (col.gameObject.CompareTag("Boom")|| col.gameObject.CompareTag("Box"))
            ColliderTriggerParent.RelayOnTriggerEnter(col, gameObject.tag);
    }
}
