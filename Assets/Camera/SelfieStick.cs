using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfieStick : MonoBehaviour {

    GameObject player;
    Vector3 armRotation;
    [SerializeField] float panSpeed = 2f;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        armRotation = transform.rotation.eulerAngles;
	}
	
	void Update () {
        armRotation.x += Input.GetAxis("RVert") * panSpeed;
        armRotation.y += Input.GetAxis("RHoriz") * panSpeed;

        gameObject.transform.position = player.transform.position;
        transform.rotation = Quaternion.Euler(armRotation);
	}
}
