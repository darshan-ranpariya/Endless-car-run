using UnityEngine;

public class CoinGenerator : MonoBehaviour {

    public ObjectPooler coinPool;

    private int distanceBWCoins = 1;
	
    public void spwanCoins(Vector3 startPos, int count)
    {
        GameObject coin;
        for (int i = 0; i < count; i++)
        {
            coin = coinPool.GetPooledObject();
            coin.transform.position = startPos;
            coin.SetActive(true);
            startPos.z += distanceBWCoins;
        }
    }
}
