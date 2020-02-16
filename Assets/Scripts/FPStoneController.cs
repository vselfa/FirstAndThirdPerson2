using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPStoneController : MonoBehaviour { // Only ONE class to control all the stones
    
    private Rigidbody rigidBody; 
    private Vector3 offset;    // The distance 
    private bool following = false; 
      
    public GameObject target; // The target to follow
    
    void Start()  { 	
        rigidBody = GetComponent<Rigidbody>(); offset = gameObject.transform.position - target.transform.position;
    }
    // To control the collisions with the First Person object from the OWN stones
    void OnCollisionEnter(Collision other) {
    
        if (other.gameObject.tag == "FPCTag") {  // Interacting ONLY with the First Person Controller
            if (gameObject.tag == "RedStoneTag") { 
                print("Xoc amb la bola roja!!");   
                Destroy (gameObject);   
            }
            if (gameObject.tag == "BlueStoneTag") { following = true;
                if (!following) { 
                    print("Xoc amb la bola blava!!");            
                }
                else {                  
                    print("Seguint bola blava!!");                  
                }
            }
            if (gameObject.tag == "YellowStoneTag") { 
                print("Xoc amb la bola groga!!"); 
                rigidBody.AddForce(Vector3.forward * Random.Range(1, 5), ForceMode.Impulse);   
            }
            // Static script to control the number of collisions
            ControlCollisions.incNumCollisions(); 
            print("Num. colisions: " + ControlCollisions.getNumCollisions());
        }
    }
    // To update the position of the camera AFTER the update of the sphere
    void LateUpdate() { 
         if (following){  
            if (gameObject.tag == "BlueStoneTag") {gameObject.transform.position = target.transform.position + offset;}
        }
    }
}
