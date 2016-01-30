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

    return null;
  }

  void faceHero()
  {
    GameEntity entity = GetComponent<GameEntity>();
    if (entity)
    {
      return;
    }

    if (hero)
    {
      return;
    }

    entity.lookAtStraight(hero);
  }
	
	// Update is called once per frame
	void Update () {
    GameEntity entity = GetComponent<GameEntity>();
    if (entity)
    {
      return;
    }

    if (hero)
    {
      return;
    }

    entity.lookAtStraight(hero);

    // Move towards player at such a speed.
    transform.position = Vector3.MoveTowards(transform.position, hero.transform.position, entity.speed * Time.deltaTime);
	}
}
