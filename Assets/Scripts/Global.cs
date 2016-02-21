using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {

  public GameObject heroPrefab;
  public GameObject heroSpawnPoint;
  public GameObject hero;

  public GameObject[] health;
  public GameObject[] emptyHealth;

	// Use this for initialization
	void Start () {
    // TODO: Reuse for spawning....
    // Add the distance between transform.position and bounds.min.y to transform.position in order to move your object up so the bottom of the mesh's bounding box is on the plane.
    float yOffset = 0.0f;

    Renderer renderer = heroPrefab.GetComponent<Renderer>();
    if (renderer)
    {
      // TODO: Using renderer might not be perfect.
      yOffset = heroPrefab.transform.position.y - renderer.bounds.min.y;
    }

    Vector3 spawnPosition = heroSpawnPoint.transform.position;
    spawnPosition.y += yOffset;
    hero = Instantiate(heroPrefab, spawnPosition, heroSpawnPoint.transform.rotation) as GameObject;
    // TODO: End reuse for spawning...
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  public void hitHero(int livesLeft)
  {
    for (int i = 0; i < emptyHealth.Length; i++)
    {
      emptyHealth[i].SetActive(false);
    }
    for (int i = 0; i < livesLeft; i++)
    {
      health[i].SetActive(true);
    }
    for (int i = livesLeft; i < health.Length; i++)
    {
      health[i].SetActive(false);
      emptyHealth[i].SetActive(true);
    }
  }

  void gainHealth(int livesLeft)
  {
    //TODO if necessary
  }
}
