using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {


    private const int bufferFrames = 1000;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private Rigidbody rigidbody;
    private GameManager gameManager;
    private int lastWrittenFrame;
    private bool loopComplete;

    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
	}
	
	void Update ()
    {
        if(gameManager.recording){
            Record();
        }else{
            PlayBack();
        }
            
    }

    private void Record()
    {
        rigidbody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;

        float time = Time.time;
        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;

        keyFrames[frame] = new MyKeyFrame(time, position, rotation);
        lastWrittenFrame = frame;
        if (lastWrittenFrame >= bufferFrames)
            loopComplete = true;
    }

    private void PlayBack(){
        rigidbody.isKinematic = true;

        int frame = Time.frameCount % bufferFrames;
        if (!loopComplete)
            frame = Time.frameCount % lastWrittenFrame;

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