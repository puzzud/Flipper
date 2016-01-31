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
      
      Destroy(this.gameObject);
    }
  }

}
