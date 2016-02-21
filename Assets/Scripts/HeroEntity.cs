using UnityEngine;
using System.Collections;

public class HeroEntity : GameEntity {

  // Variables for knocking hero after taking damage.
  int knockingTime = 0;
  Vector3 knockingDirection;
  float knockingSpeed = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    if (knockingTime > 0)
    {
      UnityEngine.Debug.Log("Knocking!");

      knockingTime--;
      transform.position = Vector3.MoveTowards(transform.position, knockingDirection + (transform.position) * knockingSpeed, knockingSpeed * Time.deltaTime);
    }
	}

  virtual public bool takeDamage( float damageAmount )
  {
    UnityEngine.Debug.Log( "Hero takeDamage" );

    // TODO: Randomly generate hero taking damage sound.
    health -= damageAmount;
    if (health < 0.0f)
    {
      health = 0.0f;
    }

    updateHealthUi();

    // TODO: Knock hero away, so that it can get another chance to collide with another enemy.
    //setKnocking(2000, new Vector3(Random.Range(0.0f, 1.0f), 0.0f, Random.Range(0.0f, 1.0f)));

    if (health <= 0.0f)
    {
      // TODO: Make some kind of hero death sound.
      // TODO: If we want to kill and knock player away with death animation, then we need to
      // not destroy it just yet and just single an animation that ends with disabling user control.
      Destroy(this.gameObject);
      return true;
    }

    // TODO: Make hero invulnerable for a split second?

    return true;
  }

  public bool updateHealthUi()
  {
    Global g = null;
    Global[] globalList = GameObject.FindObjectsOfType(typeof(Global)) as Global[];
    if (globalList.Length > 0)
    {
      g = globalList[0];
    }

    g.hitHero(Mathf.RoundToInt(health));

    return true;
  }

  public bool setKnocking(int knockingTime, Vector3 knockingDirection)
  {
    this.knockingTime = knockingTime;
    this.knockingDirection = knockingDirection;

    return true;
  }
}
