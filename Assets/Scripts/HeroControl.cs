using UnityEngine;
using System.Collections;

public class HeroControl : MonoBehaviour {

  CharacterController controller;
  public float speed = 5.0f;
  Vector3 movement = Vector3.zero;

	// Use this for initialization
	void Start () {
    controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
    movement.x = Input.GetAxis("Horizontal") * speed;
    movement.z = Input.GetAxis("Vertical") * speed;

    controller.Move(movement * Time.deltaTime);
	}
}
