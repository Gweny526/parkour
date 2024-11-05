using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEditor;


public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform targetObject;
    // [SerializeField]private Vector3 initialOffset = new Vector3(0,4,-8);
    //ici c'est la nouvelle manière d'écrire du moment que le type de variable a été annoncé avant, ici Vector3 les deux sont bon ça change rien pour le compilateur
    [SerializeField]private Vector3 initialOffset = new(0,4,-8);
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private float treshold = 0.1f;



    // void Start()
    // {
    //     initialOffset = transform.position - targetObject.position;
    // }
    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosition =  targetObject.position + initialOffset;
        transform.position = cameraPosition;
        Follow();
    }
    // with juicyness de thomas

    private void Follow()
    {
        Vector3 position = targetObject.position + initialOffset;
        if(Vector3.Distance(transform.position, position) <= treshold){
            transform.position = position;
        }
        else{
            Vector3 direction = (position - transform.position).normalized;
            transform.Translate(speed * Time.deltaTime * direction);
        }
        
    }

}
