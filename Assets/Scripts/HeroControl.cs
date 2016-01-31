using UnityEngine;
using System.Collections;

public class HeroControl : MonoBehaviour {

  CharacterController controller;
  Animator animator;

  public float speed = 5.0f;
  public Vector3 forwardDir;
  Vector3 movement = Vector3.zero;

	// Use this for initialization
	void Start () {
    controller = GetComponent<CharacterController>();

    // Animation.
    animator = GetComponent<Animator>();
    animator.Play("Idle");
	}
	
	// Update is called once per frame
	void Update () {

    // Hero Rotation (based on mouse positioning)
    Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
    Vector3 dir = Input.mousePosition - pos;
    float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.AngleAxis(angle - 90.0f, forwardDir); 

    // Hero Movement
    movement.x = Input.GetAxis("Horizontal") * speed;
    movement.z = Input.GetAxis("Vertical") * speed;

    controller.Move(movement * Time.deltaTime);

    // Animation
    if (movement.magnitude > 0.0f)
    {
      animator.Play("Run");
    }
    else
    {
      animator.Play("Idle");
    }
	}
}
