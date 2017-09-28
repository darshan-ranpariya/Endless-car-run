using UnityEngine;

public class TrafficManager : MonoBehaviour
{
    private  GameObject carPlayer;
    public int speedForce = 100;
    public float velocity;

    private Rigidbody rb;
    private Vector3 newPos;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        carPlayer = FindObjectOfType<CarMoveManager>().gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(Vector3.forward * speedForce);
        velocity = rb.velocity.magnitude;

        moveTrafficAhead();
    }

    private void moveTrafficAhead()
    {
        if (carPlayer.transform.position.z > gameObject.transform.position.z + 10f)
        {
            int xPos = Random.Range(-4, 4);
            if (xPos % 2 != 0)
            {
                xPos += 1;
            }
            newPos.x = xPos;
            newPos = gameObject.transform.position;
            newPos.z += Random.Range(50, 60);
            gameObject.transform.position = newPos;
        }
    }
}
