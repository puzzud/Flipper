using UnityEngine;
using System.Collections;

public class BoxMonsterAi : MonoBehaviour {

  GameObject hero;

	// Use this for initialization
	void Start () {
    hero = getHero();
    faceHero();
	}

  GameObject getHero()
  {
    Global[] globalList = GameObject.FindObjectsOfType(typeof(Global)) as Global[];
    if (globalList.Length > 0)
    {
      return globalList[0].hero;
    }

    UnityEngine.Debug.Log("Could not find hero.", this);

    return null;
  }

  void faceHero()
  {
    GameEntity entity = GetComponent<GameEntity>();
    if (entity == null)
    {
      return;
    }

    if (hero == null)
    {
      return;
    }

    entity.lookAtStraight(hero);
  }
	
	// Update is called once per frame
	void FixedUpdate () {
    GameEntity entity = GetComponent<GameEntity>();
    if (entity == null)
    {
      //UnityEngine.Debug.Log("Monster is not an entity?", this);
      return;
    }

    if (hero == null)
    {
      //UnityEngine.Debug.Log("Could not find a spawn point.", this);
      return;
    }

    entity.lookAtStraight(hero);

    // Move towards player at such a speed.
    //Collider collider = GetComponent<Collider>();
    
    //Rigidbody rigidBody = GetComponent<Rigidbody>();
    /*if (rigidBody)
    {
      UnityEngine.Debug.Log("HELP!!", this);

      Vector3 monsterVelocity = new Vector3();
      monsterVelocity = (hero.transform.position - transform.position) * entity.speed;
      Vector3.Normalize(monsterVelocity);

      //rigidBody.velocity = monsterVelocity;
      //rigidBody.MovePosition( hero.transform.position );

      //rigidBody.velocity = monsterVelocity;// monsterVelocity;
      //transform.position = Vector3.MoveTowards(transform.position, hero.transform.position, entity.speed * Time.deltaTime);
    }
    else
    {
      UnityEngine.Debug.Log("HREAALLLY!!", this);
    }*/

    Vector3 sameYLevelPosition = hero.transform.position;
    sameYLevelPosition.y = transform.position.y;
    transform.position = Vector3.MoveTowards(transform.position, sameYLevelPosition, entity.speed * Time.deltaTime);
	}

  void OnTriggerEnter(Collider other)
  {
    //UnityEngine.Debug.Log("Collision with " + other.name);
    // TODO: Maybe determine this object other by name?
    if (other.name == "Hero(Clone)")
    {
      HeroEntity heroEntity = other.gameObject.GetComponent<HeroEntity>();
      if (heroEntity)
      {
        heroEntity.takeDamage(1.0f);
      }
      else
      {
        UnityEngine.Debug.Log("Hero doesnt have hero entity.");
      }
    }
  }
}
