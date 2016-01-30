using UnityEngine;
using System.Collections;

public class GameEntity : MonoBehaviour {

  public float speed = 5.0f;

  public static bool getAbovePosition( GameObject gameObject, Vector3 position )
  {
    position = gameObject.transform.position;

    float yOffset = 0.0f;

    Renderer renderer = gameObject.GetComponent<Renderer>();
    if (renderer)
    {
      // TODO: Using renderer might not be perfect.
      yOffset = gameObject.transform.position.y - renderer.bounds.min.y;
    }

    position.y += yOffset;

    return true;
  }

	// Use this for initialization
	/*void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/
}
