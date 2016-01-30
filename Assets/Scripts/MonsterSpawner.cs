using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class MonsterSpawner : MonoBehaviour {

  public float minInterval = 2.0f;
  public float maxInterval = 4.0f;

  Stopwatch stopWatch = new Stopwatch();

  double nextSpawnTime = 0.0f;

  public GameObject monsterPrefab;
  public GameObject[] spawnPoints;

  void Awake()
  {
    
  }

	// Use this for initialization
	void Start () {
    stopWatch.Start();
	}
	
	// Update is called once per frame
	void Update () {
    // TODO: Maybe rather than checking the time a lot,
    // a time event mechanism can be used.
    if (stopWatch.Elapsed.TotalSeconds >= nextSpawnTime)
    {
      spawnMonster();
    }
	}

  double setNextSpawnTime()
  {
    nextSpawnTime = stopWatch.Elapsed.TotalSeconds + Random.Range(minInterval, maxInterval);
    return nextSpawnTime;
  }

  GameObject getRandomSpawnPoint()
  {
    if (spawnPoints.Length < 1)
    {
      return null;
    }

    return spawnPoints[Random.Range(0, spawnPoints.Length)];
  }

  bool spawnMonster()
  {
    GameObject spawnPoint = getRandomSpawnPoint();
    if (spawnPoint == null)
    {
      UnityEngine.Debug.Log("Could not find a spawn point.", this);
      return false;
    }

    // Get the distance between the origin of the monsterPrefab's rigid body (or self as fallback)
    // to its bottom and then spawn its above
    // the grounded spawn point.

    // Add the distance between transform.position and bounds.min.y to transform.position in order to move your object up so the bottom of the mesh's bounding box is on the plane.
    float yOffset = 0.0f;

    Renderer renderer = monsterPrefab.GetComponent<Renderer>();
    if( renderer )
    {
      // TODO: Using renderer might not be perfect.
      yOffset = monsterPrefab.transform.position.y - renderer.bounds.min.y;
    }

    Vector3 spawnPosition = spawnPoint.transform.position;
    spawnPosition.y += yOffset;
    Instantiate(monsterPrefab, spawnPosition, spawnPoint.transform.rotation);

    setNextSpawnTime();

    return true;
  }
}
