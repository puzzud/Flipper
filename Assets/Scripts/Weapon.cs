using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

  public GameObject projectilePrefab;
  public int cooldown;
  public int speed;

  static Vector3 rotateAboutVector;
  static Vector3 startingVector;

	// Use this for initialization
	void Start () {
    rotateAboutVector = new Vector3(0, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
    // Weapon Firing
    if (Input.GetMouseButtonDown(0))
    {
      Debug.Log("mouse down: rotation about: " + transform.rotation.y);
      fire(transform.position, transform.rotation);
    }
	}

  void fire(Vector3 positon, Quaternion quaternion)
  {
    // Instantiation of the projectile
    GameObject projectile = Instantiate(projectilePrefab);
    projectile.transform.position = transform.position;
    //projectilePrefab.transform.Rotate(rotateAboutVector, angle);
    //Debug.Log("Direction: " + );
    
    // Movement of the projectile
    ProjectileMovement pm = projectile.GetComponent<ProjectileMovement>();
    pm.movementDirection = quaternion * Vector3.forward;
    Debug.Log("fire: " + pm.movementDirection);
    //pm.speed = speed;
  }
}
