using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak1 : MonoBehaviour
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

        StartCoroutine(Pooling());
    }


    IEnumerator Pooling()
    {
        while (true)
        {
            foreach (GameObject obj in objectPool)
            {
                yield return new WaitForSeconds(1);

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
                    obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    obj.GetComponent<PoolableObject>().activationTime = Time.time;
                }
            }
        }
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}
