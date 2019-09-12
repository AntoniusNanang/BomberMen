using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom_Blast : MonoBehaviour
{

    public GameObject Blast;
    public int B_R = 2;
    Item_Boom_PowUp BomJ;
    public float timer = 2.0f;
    //GameObject System;

    // Start is called before the first frame update
    void Start()
    {
        BomJ = GetComponent<Item_Boom_PowUp>();
        //B_R = BomJ.Passing(B_R);
        Invoke("Megumin", timer);
    }
    GameObject Blast_P;
    bool x = true;
    bool _x = true;
    bool z = true;
    bool _z = true;

    void Megumin()  //我が名めぐみん
    {
        GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
        StartCoroutine(CrossBoom());
    }

    IEnumerator CrossBoom()
    {
        while (true)
        {
            for(int i = 0; i < B_R; i++)
            {
                yield return new WaitForSeconds(0.05f);
                if (z)
                {
                    Blast_P = Instantiate(Blast, gameObject.transform.position + (new Vector3(0, 0, i + 1)), Quaternion.identity);
                    Blast_P.transform.parent = gameObject.transform;
                    Blast_P.tag = "Blast_z";
                    Destroy(Blast_P, 0.5f);
                }
                if (_z)
                {
                    Blast_P = Instantiate(Blast, gameObject.transform.position - (new Vector3(0, 0, i + 1)), Quaternion.identity);
                    Blast_P.transform.parent = gameObject.transform;
                    Blast_P.tag = "Blast_z";
                    Destroy(Blast_P, 0.5f);
                }
                if (x)
                {
                    Blast_P = Instantiate(Blast, gameObject.transform.position + (new Vector3(i + 1, 0, 0)), Quaternion.identity);
                    Blast_P.transform.parent = gameObject.transform;
                    Blast_P.tag = "Blast_z";
                    Destroy(Blast_P, 0.5f);
                }
                if (_x)
                {
                    Blast_P = Instantiate(Blast, gameObject.transform.position - (new Vector3(i + 1, 0, 0)), Quaternion.identity);
                    Blast_P.transform.parent = gameObject.transform;
                    Blast_P.tag = "Blast_z";
                    Destroy(Blast_P, 0.5f);
                }
            }
            Destroy(gameObject, 0.5f);
            yield break;
        }
    }
}
