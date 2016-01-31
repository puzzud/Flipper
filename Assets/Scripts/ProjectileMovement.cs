using UnityEngine;
using System.Collections;

public class ProjectileMovement : MonoBehaviour {

  public Vector3 movementDirection;
  public Vector3 startLocation;
  public int speed;
  public int maxDistance;
  public float distance;
  public Weapon weapon;

	// Use this for initialization
	void Start () {
    maxDistance = 30;
	}
	
	// Update is called once per frame
	void Update () {
    transform.position = Vector3.MoveTowards(transform.position, movementDirection + transform.position, speed * Time.deltaTime);

    distance = Vector3.Distance(startLocation, transform.position);
    if ( distance > maxDistance)
    {
      weapon.projectileCount--;
      Destroy(this.gameObject);
    }
	}

  void OnTriggerEnter(Collider other)
  {
    if (other.name == "Box Monster(Clone)")
    {
      Debug.Log("Box HIT!!!");

      GameEntity monsterEntity = other.GetComponent<GameEntity>();
      if (monsterEntity)
      {
        // TODO: Base this damage based on weapon.
        monsterEntity.takeDamage(1.0f);
      }
      else
      {
        // Destroy monster in case it doesnt have an entity.
        Destroy(other.gameObject);
      }

      weapon.projectileCount--;
      Destroy(this.gameObject);
    }
  }

}
