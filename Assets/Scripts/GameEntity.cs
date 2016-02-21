using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameEntity : MonoBehaviour {

  public float health;

  public float speed = 5.0f;

  public List<GameEntity> inventory;

  // TODO: Intended for garbage and other items in inventory.
  //bool active = true;

  void Start()
  {
    if (health <= 0)
    {
      health = 1.0f;
    }
  }

  // TODO: Not used? Needs improvement and refactor.
  /*public static bool getAbovePosition( GameObject gameObject, Vector3 position )
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
  }*/

  //! Make this GameEntity look at a GameObject without
  //! pivoting up or down (looks straight head but turns).
  public bool lookAtStraight(GameObject lookAtObject)
  {
    Vector3 lookAtStraightPosition = lookAtObject.transform.position;
    lookAtStraightPosition.y = transform.position.y;
    transform.LookAt(lookAtStraightPosition);

    return true;
  }

  public void show(bool show)
  {
    Renderer _renderer = GetComponent<Renderer>();
    if (_renderer)
    {
      _renderer.enabled = show;

      // TODO: Probably back to base active on visibility.
      //active = show;
    }

    //UnityEngine.Debug.Log("no renderer");
  }

	// Use this for initialization
	/*void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/

  virtual public bool takeDamage(float damageAmount)
  {
    health = 0.0f;
    Destroy(gameObject);

    return true;
  }
}
