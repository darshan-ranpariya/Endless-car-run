using UnityEngine;

public class FuelGanerator : MonoBehaviour
{
    public ObjectPooler fuelPool;

    public void spwanFuel(Vector3 startPos)
    {
        GameObject coin = fuelPool.GetPooledObject();
        coin.transform.position = startPos;
        coin.SetActive(true);
    }
}
