using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rocketRigidBody;
    AudioSource thrustAudio;

    [SerializeField]
    float rcsThrust = 100f;
    [SerializeField]
    float mainThurst = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rocketRigidBody = GetComponent<Rigidbody>();
        thrustAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Thrust();
        Rotation();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("OK");
                break;
            case "Fuel":
                print("Fuel");
                break;
            default:
                print("dead");
                break;
        }
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            float thrustThisFrame = mainThurst * Time.deltaTime;
            //Thrust Rocket
            rocketRigidBody.AddRelativeForce(Vector3.up * thrustThisFrame);
            if (!thrustAudio.isPlaying)
                thrustAudio.Play();
        }
        else
        {
            thrustAudio.Stop();
        }
    }
    private void Rotation()
    {
        rocketRigidBody.freezeRotation = true;

        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Rotate Left
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //Rotate Right
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        rocketRigidBody.freezeRotation = false;
    }
}
