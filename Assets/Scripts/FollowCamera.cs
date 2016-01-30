using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

  public GameObject objectToFollow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame (use LateUpdate for cameras)
	void LateUpdate () {
    transform.LookAt(objectToFollow.transform);
	}
}
