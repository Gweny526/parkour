using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    //fonctionne très bien mais Thomas nous montre une autre manière

    // void OnTriggerEnter(Collider other)
    // {
    //     other.transform.position = new Vector3(0,1,0);
    // }

    // private Vector3 teleportPosition;
    // [SerializeField] Transform groundTransform;
    // [SerializeField] float fall = 2f;
    // void Start()
    // {
    //     teleportPosition = transform.position;
    // }
    // void Update(){
    //     if(transform.position.y < groundTransform.position.y){
    //         TeleportIt();
    //     }
    // }
    // private void TeleportIt(){
    //     transform.position = teleportPosition; 
    //     if(TryGetComponent(out Rigidbody rigidbody)){
    //         rigidbody.velocity = Vector3.zero;
    //     }
    // }
    // void OnCollisionEnter(Collision collision){
    //     if(collision.collider.CompareTag("Obstacle")){
    //         TeleportIt();
    //     }
    // }
    private Vector3 teleportPosition;
    public Transform groundTransform;
    public float fallingDistance;
    void Start()
    {
        teleportPosition = transform.position;
    }
    void Update()
    {
        if(transform.position.y + fallingDistance< groundTransform.position.y)
        {
            TeleportIt();
        }    
    }
    // Update is called once per frame
    private void TeleportIt()
    {
        transform.position = teleportPosition;
        if(TryGetComponent(out Rigidbody rb))
        {
            rb.velocity = Vector3.zero;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            TeleportIt();
        }
    }
}
