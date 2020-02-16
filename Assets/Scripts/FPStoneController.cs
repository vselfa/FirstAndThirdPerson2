using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To manage scenes 
using UnityEngine.SceneManagement;

public class FPStoneController : MonoBehaviour { // Only ONE class to control all the stones
    
    private Rigidbody rigidBody; 
    private Vector3 offset;    // The distance 
    private bool following = false; 
    // static: to keep values between updates
    private static int orderToFollow = 0;

    public GameObject target; // The target to follow
    
    void Start()  { 	
        rigidBody = GetComponent<Rigidbody>(); 
        offset = gameObject.transform.position - target.transform.position;
    }
    // To control the collisions with the First Person object from the OWN stones
    void OnCollisionEnter(Collision other) {
    
        // Follow an order to change of scene: Red, Blue and Yellow
        if (other.gameObject.tag == "FPCTag") {  // Interacting ONLY with the First Person Controller
           
           if (gameObject.tag == "RedStoneTag") { 
                Destroy (gameObject);   
                if (orderToFollow == 0) orderToFollow = 1;
                print("Xoc amb la bola roja!! Order: " +  orderToFollow);   
            }

            if (gameObject.tag == "BlueStoneTag") { 
                following = true;
                if (orderToFollow == 1) orderToFollow = 2;
                print("Seguint bola blava!! Order: " +  orderToFollow);  
            }

            if (gameObject.tag == "YellowStoneTag") { 
                rigidBody.AddForce(Vector3.forward * Random.Range(1, 5), ForceMode.Impulse);   
                if (orderToFollow == 2) orderToFollow = 3;
                print("Xoc amb la bola groga!! Order: " +  orderToFollow);   
            }

            // Static script to control the number of collisions
            ControlCollisions.incNumCollisions(); 
            print("Num. colisions: " + ControlCollisions.getNumCollisions());
        }
    }
    // To update the position of the camera AFTER the update of the sphere
    void LateUpdate() { 
         if (following){  
            if (gameObject.tag == "BlueStoneTag") {
                gameObject.transform.position = target.transform.position + offset;
            }
        }

        if (orderToFollow == 3) {
            SceneManager.LoadScene ("ThirdPerson");
        }
    }
}