using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlienMover : MonoBehaviour
{
    float gravityV = -9.81f;
    bool grounded = false;
    public float speed = 12f;
    float jumpH = 5f;
    float score = 0;

    Transform trnsf;
    CharacterController cntrl;
    [SerializeField] TextMeshProUGUI scoreTMP;
    void Start()
    {
        trnsf = GetComponent<Transform>();
        cntrl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * 5;
        float vertical = Input.GetAxis("Vertical");

        cntrl.Move(trnsf.forward * vertical * speed * Time.deltaTime);
        cntrl.Move(trnsf.up * gravityV * Time.deltaTime);
        trnsf.Rotate(0, mouseX, 0);
        
        if(Input.GetKeyDown("space") && grounded == true){
            cntrl.Move(trnsf.up * jumpH);
        }
    }

    void OnControllerColliderHit(ControllerColliderHit col){
        if(col.gameObject.tag == "floor"){
            grounded = true;

        }
        if(col.gameObject.tag == "item"){
            Destroy(col.gameObject);
            score += 0.5f;
            scoreTMP.text = score + ""; 

        }
    }
}
