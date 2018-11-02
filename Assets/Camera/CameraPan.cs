using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour {

    private GameObject player;
    private Transform initialTransform;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        initialTransform = gameObject.transform;
	}

    //void Update () {
    //       gameObject.transform.position = player.transform.position;
    //       //Debug.Log(camera.name);
    //}
    private void LateUpdate()
    {
        transform.LookAt(player.transform);
        //Vector3 newCameraPos = player.transform.position;
        //newCameraPos += initialTransform.position;
        //gameObject.transform.position = newCameraPos;
    }
}
