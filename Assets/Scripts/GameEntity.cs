using UnityEngine;
using System.Collections;

public class GameEntity : MonoBehaviour {

  public float speed = 5.0f;

  // TODO: Not used? Needs improvement and refactor.
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

  //! Make this GameEntity look at a GameObject without
  //! pivoting up or down (looks straight head but turns).
  public bool lookAtStraight(GameObject lookAtObject)
  {
    Vector3 lookAtStraightPosition = lookAtObject.transform.position;
    lookAtStraightPosition.y = transform.position.y;
    transform.LookAt(lookAtStraightPosition);

    return true;
  }

	// Use this for initialization
	/*void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/
}
