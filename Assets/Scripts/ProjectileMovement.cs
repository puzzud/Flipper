using UnityEngine;
using System.Collections;

public class ProjectileMovement : MonoBehaviour {

  public Vector3 movementDirection;
  public int speed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
    transform.position = Vector3.MoveTowards(transform.position, movementDirection + transform.position, speed * Time.deltaTime);    
	}

  void OnTriggerEnter(Collider other)
  {
    if (other.name == "Box Monster(Clone)")
    {
      Debug.Log("Box HIT!!!");
      Destroy(other.gameObject);
      Destroy(this.gameObject);
    }
  }

}
