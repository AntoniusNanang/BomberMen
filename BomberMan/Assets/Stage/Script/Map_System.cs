using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_System : MonoBehaviour
{
    Map map;
    public GameObject[] mapObjPre;
    void Start()
    {
        map = GetComponent<Map>(); 
        CreateStage();
    }

    void CreateStage()
    {
        int[,,] data = map.GetMapData();
        for(int y = 0; y<data.GetLength(0); y++)
        {
            if(y == 1)//上
            {
                for(int x = 0; x < data.GetLength(1); x++)
                {
                    for(int z = 0; z < data.GetLength(1); z++)
                    {
                        GameObject obj;
                        if (RandomBox())
                        {
                            if (data[y, z, x] == 2)
                            {
                                obj = Instantiate(mapObjPre[8],
                                      transform.position + new Vector3(x, y, z), Quaternion.identity);
                                obj.transform.parent = transform;
                            }
                            else
                            {
                                obj = Instantiate(mapObjPre[data[y, z, x]],
                                     transform.position + new Vector3(x, y, z), Quaternion.identity);
                                obj.transform.parent = transform;
                            }
                        }
                        else
                        {
                            obj = Instantiate(mapObjPre[data[y, z, x]],
                                 transform.position + new Vector3(x, y, z), Quaternion.identity);
                            obj.transform.parent = transform;
                        }
                    }
                }
                //transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
            }
            if (y == 0)//下
            {
                for (int x = 0; x < data.GetLength(2); x++)
                {
                    for (int z = 0; z < data.GetLength(2); z++)
                    {
                        GameObject obj = Instantiate(mapObjPre[data[y, z, x]],
                            transform.position + new Vector3(x, y, z), Quaternion.identity);
                        obj.transform.parent = transform;
                    }
                }
            }
        }
    }

    bool RandomBox()
    {
        return Random.Range(0, 2) == 0 || Random.Range(0,2) == 1 ;
    }

}
