using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPStoneController : MonoBehaviour { // Only ONE class to control all the stones
    private Rigidbody rigidBody; 
    private Vector3 offset;    // The distance 
    private bool following = false;   

    public GameObject target; // The target to follow

    void Start()  { 	
        rigidBody = GetComponent<Rigidbody>(); offset = gameObject.transform.position - target.transform.position;
    }
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "TPCTag") {  // Interacting ONLY with the First Person Controller
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

            ControlCollisions.incNumCollisions(); print("Num. colisions: " + ControlCollisions.getNumCollisions());

        }
    }
    void LateUpdate() { // To update the position of the camera AFTER the update of the sphere
         if (following){  
            if (gameObject.tag == "BlueStoneTag") {
                gameObject.transform.position = target.transform.position + offset;
            }
        }
    }
}
