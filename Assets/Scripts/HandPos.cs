using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPos : MonoBehaviour
{
    [SerializeField]private GameObject leftArmTarget;
    [SerializeField]private GameObject rightArmTarget;
    [SerializeField]private Vector3 leftArmPos;
    [SerializeField]private Vector3 rightArmPos;
    [SerializeField]private Vector3 leftArmRot;
    [SerializeField]private Vector3 rightArmRot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftArmTarget.transform.position = leftArmPos;
        rightArmTarget.transform.position = rightArmPos;

        leftArmTarget.transform.rotation = Quaternion.Euler(leftArmRot);
        rightArmTarget.transform.rotation = Quaternion.Euler(rightArmRot);
    }
}
