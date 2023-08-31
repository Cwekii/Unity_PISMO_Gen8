using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public GameObject prefab;
    public int initialPoolSize = 10;

   [SerializeField] private List<GameObject> objectPool = new List<GameObject>();


    private void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject tempObj = Instantiate(prefab, transform);
            tempObj.SetActive(false);
            objectPool.Add(tempObj);
        }
    }


    private void Update()
    {
        foreach (GameObject obj in objectPool)
        {

            if (obj.activeInHierarchy && 
                Time.time - obj.GetComponent<PoolableObject>().activationTime >= 1)
            {
                ReturnObjectToPool(obj);
            }

            if (!obj.activeInHierarchy)
            {

                obj.transform.localPosition = transform.localPosition;
                obj.transform.rotation = Quaternion.identity;
                obj.SetActive(true);

                obj.GetComponent<PoolableObject>().activationTime = Time.time;
            }


        }
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}
