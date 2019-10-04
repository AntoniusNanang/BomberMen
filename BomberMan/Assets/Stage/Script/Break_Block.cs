using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break_Block : MonoBehaviour
{
    public GameObject[] item_pre = new GameObject[2];
    GameObject obj;
    public GameObject child;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Balst"))
        {
            gameObject.SetActive(false);
            child.SetActive(false);
            if(Random.Range(0,2) == 0|| Random.Range(0, 2) == 1)
            {
                Invoke("CreateItem", 0.8f);
            }

        }
    }
    void CreateItem()
    {
      
        switch (Random.Range(0, 2))
        {
            case 0:
                obj = Instantiate(item_pre[0], gameObject.transform.position, item_pre[0].transform.rotation) as GameObject;
                obj.GetComponent<Item>().itemType = Item.ItemType.Pow_UP;
                break;
            case 1:
                obj = Instantiate(item_pre[1], gameObject.transform.position, item_pre[1].transform.rotation) as GameObject;
                obj.GetComponent<Item>().itemType = Item.ItemType.Bomb_UP;
                break;
            default:
                break;
        }
    }
}
