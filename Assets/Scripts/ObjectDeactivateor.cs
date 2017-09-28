using UnityEngine;

public class ObjectDeactivateor : MonoBehaviour
{

    private GameObject playerCar;

    private void Awake()
    {
        playerCar = FindObjectOfType<CarMoveManager>().gameObject;
    }
    private void OnBecameInvisible()
    {
        if (playerCar.transform.position.z > gameObject.transform.position.z + 10f)
        {
            gameObject.SetActive(false);
        }
    }
}
