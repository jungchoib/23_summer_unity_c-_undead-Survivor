using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 2 frepeb val
    public GameObject[] prefabs;

    // 2 Pool List
    List<GameObject>[] pools;
    
    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++){
            pools[index] = new List<GameObject>();
        }
    }
    public GameObject Get(int index)
    {
        GameObject select = null;
        // approach disabled gameobject in pools
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                // if you approach it is select
                select = item;
                select.SetActive(true);
                break;
            }
        }
        // if you not approach
        if (!select)
        {
            // make new thing and it is select
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }
        return select;
    }
}
