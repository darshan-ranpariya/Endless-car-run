using UnityEngine;

public class RoadManager : MonoBehaviour {

    public GameObject player;

    private const int roadDistance = 1000;
    private Vector3 newPos;

    private void Awake()
    {
        player = FindObjectOfType<CarMoveManager>().gameObject;
    }

    private void OnBecameInvisible()
    {
        if (gameObject != null)
        {
            if (player.transform.position.z > gameObject.transform.position.z)
            {
                newPos = gameObject.transform.position;
                newPos.z += roadDistance;
                gameObject.transform.position = newPos;
            }
        }
    }
}
