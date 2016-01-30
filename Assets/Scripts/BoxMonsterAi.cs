using UnityEngine;
using System.Collections;

public class BoxMonsterAi : MonoBehaviour {

	// Use this for initialization
	void Start () {
	  
	}
	
	// Update is called once per frame
	void Update () {
    GameEntity entity = GetComponent<GameEntity>();
    if (entity)
    {
      return;
    }



    //transform.LookAt(objectToFollow.transform);

    //entity.speed;
	}
}
