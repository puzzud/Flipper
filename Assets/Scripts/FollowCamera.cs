using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

  public GameObject global;
  public GameObject objectToFollow;

	// Use this for initialization
	void Start () {
    if (global == null)
    {
      return;
    }

    Global g = global.GetComponent<Global>();
    if (g == null)
    {
      return;
    }

    objectToFollow = g.hero;
	}
	
	// Update is called once per frame (use LateUpdate for cameras)
	void LateUpdate () {
    if (objectToFollow != null)
    {
      transform.LookAt(objectToFollow.transform);
    }
    else
    {
      Global g = global.GetComponent<Global>();
      if (g == null)
      {
        return;
      }

      objectToFollow = g.hero;
    }
	}
}
