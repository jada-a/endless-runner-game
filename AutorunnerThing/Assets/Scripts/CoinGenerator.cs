using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField]
    internal ObjectPooler coinPool;

    [SerializeField]
    internal float distanceBetweenCoins;

    public void SpawnCoins(Vector3 coinPosition)
    {
        GameObject coin1 = coinPool.GetPooledObject();

        coin1.transform.position = coinPosition;
        coin1.SetActive(true);

        GameObject coin2 = coinPool.GetPooledObject();

        coin2.transform.position = new Vector3(coinPosition.x - distanceBetweenCoins, coinPosition.y, coinPosition.z);
        coin2.SetActive(true);

        GameObject coin3 = coinPool.GetPooledObject();

        coin3.transform.position = new Vector3(coinPosition.x + distanceBetweenCoins, coinPosition.y, coinPosition.z);
        coin3.SetActive(true);


    }
}
