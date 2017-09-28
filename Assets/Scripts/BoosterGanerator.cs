using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterGanerator : MonoBehaviour {

    public ObjectPooler boosterPool;

    public void spwanBooster(Vector3 startPos)
    {
        GameObject coin = boosterPool.GetPooledObject();
        coin.transform.position = startPos;
        coin.SetActive(true);
    }
}
