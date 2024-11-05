using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] //va forcé l'objet sur lequel on met le script d'avoir un rigidbody
public class PlayerControl : MonoBehaviour
{

    //public InputActions actions;

    public InputActionAsset actions;
    public float speed = 1f;
    private InputAction xAxis;
    private InputAction jump;
    public Rigidbody rb;
    [SerializeField]private float jumpAmount = 150f;
    // [SerializeField]private bool isGrounded;
    private bool isGrounded {get{
        if(Physics.Raycast(transform.position, Vector3.down, 0.6f)){
            return true;
        }
        return false;
    }set{}}

    
    
    void Awake()
    {
        xAxis = actions.FindActionMap("CubeActionsMap").FindAction("XAxis");
        jump = actions.FindActionMap("CubeActionsMap").FindAction("Jump");
        rb = GetComponent<Rigidbody>();
        
    }

    void OnEnable()
    {
        actions.FindActionMap("CubeActionsMap").Enable();
        jump.performed += OnJump;
    }

    void OnDisable()
    {
        actions.FindActionMap("CubeActionsMap").Disable();
        jump.performed -= OnJump;
    }

    void Update()
    {
        MoveX();
        MoveZ();
        
        // plane();
    }
    void OnJump(InputAction. CallbackContext context)
    {
        if (!isGrounded)return;
        {
                
            rb.AddForce(Vector3.up * jumpAmount);
        }
    }

    
    // void plane()
    // {
    //     if(transform.position.z >= 177 || transform.position.x <= -11 || transform.position.x >= 10)
    //     {
    //         transform.position = new Vector3(0,1,0);
    //     }
    // }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    private void MoveX()
    {
        float xMove = xAxis.ReadValue<float>();
        //Time.deltaTime = le temps d'une frame
        transform.position += speed * Time.deltaTime * xMove * transform.right; //transform.right c'est la droite de l'objet pas du monde 

    }
    private void MoveZ()
    {
        
        // transform.position += speed * Time.deltaTime * transform.forward;
        
        //exemple de correction donné par thomas le mien était tout a fait bon

        //calcul plus rapide parce que prend 2 multiplication de moins
        Vector3 movement = Time.deltaTime * speed * transform.forward;
        transform.Translate(movement);
    }
}
