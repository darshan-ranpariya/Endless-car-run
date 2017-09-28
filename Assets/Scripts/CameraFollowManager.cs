using UnityEngine;

public class CameraFollowManager : MonoBehaviour {

    public GameObject carObject;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - carObject.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = new Vector3(transform.position.x,transform.position.y,carObject.transform.position.z + offset.z);
	}
}
