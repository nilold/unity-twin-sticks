using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {


    private const int bufferFrames = 100;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private Rigidbody rigidbody;

    void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        Record();
    }

    private void Record()
    {
        int frame = Time.frameCount % bufferFrames;

        float time = Time.time;
        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;

        keyFrames[frame] = new MyKeyFrame(time, position, rotation);
    }

    private void PlayBack(){
        rigidbody.isKinematic = true;
        int frame = Time.frameCount % bufferFrames;

        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
    }
}

public struct MyKeyFrame {
    public float time;
    public Vector3 position;
    public Quaternion rotation;

    public MyKeyFrame(float time, Vector3 position, Quaternion rotation)
    {
        this.time = time;
        this.position = position;
        this.rotation = rotation;
    }
}