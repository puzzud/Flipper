using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class MonsterSpawner : MonoBehaviour {

  public float minInterval = 2.0f;
  public float maxInterval = 12.0f;

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
      return false;
    }
    
    Instantiate(monsterPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
    
    setNextSpawnTime();

    return true;
  }
}
