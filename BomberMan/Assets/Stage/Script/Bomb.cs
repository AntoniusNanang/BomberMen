using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionPrefub;
    public LayerMask[] levelMask;
    public int Pow = 3;
    public Player_2 bomb;
    public Move_to com_Bomb;
    public Move_to02 com1_Bomb;
    public int bombs = 1;
    private bool exploded = false;

    // Start is called before the first frame update
    void Start()
    {
        bomb.canDropBombs = new bool[4];
        Invoke("Explode", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void Explode()
    {
        //爆弾の位置に爆発のエフェクトを作成
        Instantiate(explosionPrefub, transform.position, Quaternion.identity);
        GetComponent<MeshRenderer>().enabled = false;
        exploded = true;
        //爆風を広げる
        StartCoroutine(CreateExplosion(Vector3.forward));
        StartCoroutine(CreateExplosion(Vector3.right));
        StartCoroutine(CreateExplosion(Vector3.back));
        StartCoroutine(CreateExplosion(Vector3.left));
        transform.Find("Collider").gameObject.SetActive(false);

        Destroy(gameObject, 0.3f);
        bomb.BombNum(bombs);
        com_Bomb.BombNu(bombs);
       
    }

    void WhoBomb()
    {
        
    }

    private IEnumerator CreateExplosion(Vector3 direction)
    {
        for (int i = 1; i < Pow; i++)
        {
            RaycastHit hit;
            Physics.Raycast
                (
                    transform.position + new Vector3(0, 0.5f, 0),
                    direction,
                    out hit,
                    i,
                    levelMask[0]
                );
            if (!hit.collider)
            {
                Instantiate(explosionPrefub, transform.position + (i * direction), explosionPrefub.transform.rotation);
            }
            else break;
            //爆風を広げた先に壊れるブロックある場合
            if (Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), direction, out hit, i, levelMask[1]))
            {
                Destroy(hit.collider.gameObject, 1f);
                break;
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (!exploded && other.CompareTag("Balst"))
        {
            CancelInvoke("Explode");
            Explode();
        }
    }
}
