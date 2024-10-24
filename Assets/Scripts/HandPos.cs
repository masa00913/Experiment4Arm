using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandPos : MonoBehaviour
{
    [SerializeField]private GameObject leftArmTarget;
    [SerializeField]private GameObject rightArmTarget;
    [SerializeField]private Vector3 leftArmPos;
    [SerializeField]private Vector3 rightArmPos;
    [SerializeField]private Vector3 leftArmRot;
    [SerializeField]private Vector3 rightArmRot;
    [SerializeField]private OVRSkeleton OVRleftHand;
    [SerializeField]private OVRSkeleton OVRrightHand;

    [SerializeField]private Vector3 l_angle_bone_hand;
    [SerializeField]private Vector3 l_angle_bone_Thumb3;
    [SerializeField]private Vector3 l_angle_bone_Thumb2;
    [SerializeField]private Vector3 l_angle_bone_Thumb1;
    [SerializeField]private Vector3 l_angle_bone_Thumb0;
    [SerializeField]private Vector3 l_angle_bone_Index3;
    [SerializeField]private Vector3 l_angle_bone_Index2;
    [SerializeField]private Vector3 l_angle_bone_Index1;
    [SerializeField]private Vector3 l_angle_bone_Middle3;
    [SerializeField]private Vector3 l_angle_bone_Middle2;
    [SerializeField]private Vector3 l_angle_bone_Middle1;
    [SerializeField]private Vector3 l_angle_bone_Ring3;
    [SerializeField]private Vector3 l_angle_bone_Ring2;
    [SerializeField]private Vector3 l_angle_bone_Ring1;
    [SerializeField]private Vector3 l_angle_bone_Pinky3;
    [SerializeField]private Vector3 l_angle_bone_Pinky2;
    [SerializeField]private Vector3 l_angle_bone_Pinky1;
    [SerializeField]private Vector3 l_angle_bone_Pinky0;
    [SerializeField]private Vector3 r_angle_bone_hand;
    [SerializeField]private Vector3 r_angle_bone_Thumb3;
    [SerializeField]private Vector3 r_angle_bone_Thumb2;
    [SerializeField]private Vector3 r_angle_bone_Thumb1;
    [SerializeField]private Vector3 r_angle_bone_Thumb0;
    [SerializeField]private Vector3 r_angle_bone_Index3;
    [SerializeField]private Vector3 r_angle_bone_Index2;
    [SerializeField]private Vector3 r_angle_bone_Index1;
    [SerializeField]private Vector3 r_angle_bone_Middle3;
    [SerializeField]private Vector3 r_angle_bone_Middle2;
    [SerializeField]private Vector3 r_angle_bone_Middle1;
    [SerializeField]private Vector3 r_angle_bone_Ring3;
    [SerializeField]private Vector3 r_angle_bone_Ring2;
    [SerializeField]private Vector3 r_angle_bone_Ring1;
    [SerializeField]private Vector3 r_angle_bone_Pinky3;
    [SerializeField]private Vector3 r_angle_bone_Pinky2;
    [SerializeField]private Vector3 r_angle_bone_Pinky1;
    [SerializeField]private Vector3 r_angle_bone_Pinky0;

    [SerializeField]private Transform l_hand_hand;
    [SerializeField]private Transform l_hand_Thumb3;
    [SerializeField]private Transform l_hand_Thumb2;
    [SerializeField]private Transform l_hand_Thumb1;
    [SerializeField]private Transform l_hand_Thumb0;
    [SerializeField]private Transform l_hand_Index3;
    [SerializeField]private Transform l_hand_Index2;
    [SerializeField]private Transform l_hand_Index1;
    [SerializeField]private Transform l_hand_Middle3;
    [SerializeField]private Transform l_hand_Middle2;
    [SerializeField]private Transform l_hand_Middle1;
    [SerializeField]private Transform l_hand_Ring3;
    [SerializeField]private Transform l_hand_Ring2;
    [SerializeField]private Transform l_hand_Ring1;
    [SerializeField]private Transform l_hand_Pinky3;
    [SerializeField]private Transform l_hand_Pinky2;
    [SerializeField]private Transform l_hand_Pinky1;
    [SerializeField]private Transform l_hand_Pinky0;

    [SerializeField]private Transform l_bone_hand;
    [SerializeField]private Transform l_bone_Thumb3;
    [SerializeField]private Transform l_bone_Thumb2;
    [SerializeField]private Transform l_bone_Thumb1;
    [SerializeField]private Transform l_bone_Thumb0;
    [SerializeField]private Transform l_bone_Index3;
    [SerializeField]private Transform l_bone_Index2;
    [SerializeField]private Transform l_bone_Index1;
    [SerializeField]private Transform l_bone_Middle3;
    [SerializeField]private Transform l_bone_Middle2;
    [SerializeField]private Transform l_bone_Middle1;
    [SerializeField]private Transform l_bone_Ring3;
    [SerializeField]private Transform l_bone_Ring2;
    [SerializeField]private Transform l_bone_Ring1;
    [SerializeField]private Transform l_bone_Pinky3;
    [SerializeField]private Transform l_bone_Pinky2;
    [SerializeField]private Transform l_bone_Pinky1;
    [SerializeField]private Transform l_bone_Pinky0;

    [SerializeField]private Transform r_hand_hand;
    [SerializeField]private Transform r_hand_Thumb3;
    [SerializeField]private Transform r_hand_Thumb2;
    [SerializeField]private Transform r_hand_Thumb1;
    [SerializeField]private Transform r_hand_Thumb0;
    [SerializeField]private Transform r_hand_Index3;
    [SerializeField]private Transform r_hand_Index2;
    [SerializeField]private Transform r_hand_Index1;
    [SerializeField]private Transform r_hand_Middle3;
    [SerializeField]private Transform r_hand_Middle2;
    [SerializeField]private Transform r_hand_Middle1;
    [SerializeField]private Transform r_hand_Ring3;
    [SerializeField]private Transform r_hand_Ring2;
    [SerializeField]private Transform r_hand_Ring1;
    [SerializeField]private Transform r_hand_Pinky3;
    [SerializeField]private Transform r_hand_Pinky2;
    [SerializeField]private Transform r_hand_Pinky1;
    [SerializeField]private Transform r_hand_Pinky0;

    [SerializeField]private Transform r_bone_hand;
    [SerializeField]private Transform r_bone_Thumb3;
    [SerializeField]private Transform r_bone_Thumb2;
    [SerializeField]private Transform r_bone_Thumb1;
    [SerializeField]private Transform r_bone_Thumb0;
    [SerializeField]private Transform r_bone_Index3;
    [SerializeField]private Transform r_bone_Index2;
    [SerializeField]private Transform r_bone_Index1;
    [SerializeField]private Transform r_bone_Middle3;
    [SerializeField]private Transform r_bone_Middle2;
    [SerializeField]private Transform r_bone_Middle1;
    [SerializeField]private Transform r_bone_Ring3;
    [SerializeField]private Transform r_bone_Ring2;
    [SerializeField]private Transform r_bone_Ring1;
    [SerializeField]private Transform r_bone_Pinky3;
    [SerializeField]private Transform r_bone_Pinky2;
    [SerializeField]private Transform r_bone_Pinky1;
    [SerializeField]private Transform r_bone_Pinky0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftArmTarget.transform.position = l_bone_hand.position;
        rightArmTarget.transform.position = r_bone_hand.position;

        leftArmTarget.transform.rotation = l_bone_hand.rotation * Quaternion.Euler(l_angle_bone_hand);
        rightArmTarget.transform.rotation = r_bone_hand.rotation * Quaternion.Euler(r_angle_bone_hand);
        leftHand();
        rightHand();
    }


    private void leftHand(){
        // OVRSkeleton の Bones プロパティを使って、全ての関節の情報を取得
        IList<OVRBone> bones = OVRleftHand.Bones;
        if(bones.Count <20 ) return;
        Debug.Log(bones.Count);
        // var l_bone_Thumb3 = bones[(int)OVRSkeleton.BoneId.Hand_Thumb3];
        // var l_bone_Thumb2 = bones[(int)OVRSkeleton.BoneId.Hand_Thumb2];
        // var l_bone_Thumb1 = bones[(int)OVRSkeleton.BoneId.Hand_Thumb1];
        // var l_bone_Thumb0 = bones[(int)OVRSkeleton.BoneId.Hand_Thumb0];
        // var l_bone_Index3 = bones[(int)OVRSkeleton.BoneId.Hand_Index3];
        // var l_bone_Index2 = bones[(int)OVRSkeleton.BoneId.Hand_Index2];
        // var l_bone_Index1 = bones[(int)OVRSkeleton.BoneId.Hand_Index1];
        // var l_bone_Middle3 = bones[(int)OVRSkeleton.BoneId.Hand_Middle3];
        // var l_bone_Middle2 = bones[(int)OVRSkeleton.BoneId.Hand_Middle2];
        // var l_bone_Middle1 = bones[(int)OVRSkeleton.BoneId.Hand_Middle1];
        // var l_bone_Ring3 = bones[(int)OVRSkeleton.BoneId.Hand_Ring3];
        // var l_bone_Ring2 = bones[(int)OVRSkeleton.BoneId.Hand_Ring2];
        // var l_bone_Ring1 = bones[(int)OVRSkeleton.BoneId.Hand_Ring1];
        // var l_bone_Pinky3 = bones[(int)OVRSkeleton.BoneId.Hand_Pinky3];
        // var l_bone_Pinky2 = bones[(int)OVRSkeleton.BoneId.Hand_Pinky2];
        // var l_bone_Pinky1 = bones[(int)OVRSkeleton.BoneId.Hand_Pinky1];
        // var l_bone_Pinky0 = bones[(int)OVRSkeleton.BoneId.Hand_Pinky0];

        
        
        // Debug.Log($"Bone: {bone_Thumb3.Id}, Position: {bone_Thumb3.Transform.position}, Rotation: {bone_Thumb3.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Thumb2.Id}, Position: {bone_Thumb2.Transform.position}, Rotation: {bone_Thumb2.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Thumb1.Id}, Position: {bone_Thumb1.Transform.position}, Rotation: {bone_Thumb1.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Thumb0.Id}, Position: {bone_Thumb0.Transform.position}, Rotation: {bone_Thumb0.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Index3.Id}, Position: {bone_Index3.Transform.position}, Rotation: {bone_Index3.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Index2.Id}, Position: {bone_Index2.Transform.position}, Rotation: {bone_Index2.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Index1.Id}, Position: {bone_Index1.Transform.position}, Rotation: {bone_Index1.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Middle3.Id}, Position: {bone_Middle3.Transform.position}, Rotation: {bone_Middle3.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Middle2.Id}, Position: {bone_Middle2.Transform.position}, Rotation: {bone_Middle2.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Middle1.Id}, Position: {bone_Middle1.Transform.position}, Rotation: {bone_Middle1.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Ring3.Id}, Position: {bone_Ring3.Transform.position}, Rotation: {bone_Ring3.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Ring2.Id}, Position: {bone_Ring2.Transform.position}, Rotation: {bone_Ring2.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Ring1.Id}, Position: {bone_Ring1.Transform.position}, Rotation: {bone_Ring1.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Pinky3.Id}, Position: {bone_Pinky3.Transform.position}, Rotation: {bone_Pinky0.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Pinky2.Id}, Position: {bone_Pinky2.Transform.position}, Rotation: {bone_Pinky1.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Pinky1.Id}, Position: {bone_Pinky1.Transform.position}, Rotation: {bone_Pinky2.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Pinky0.Id}, Position: {bone_Pinky0.Transform.position}, Rotation: {bone_Pinky3.Transform.rotation}");

        l_hand_Thumb3.rotation = l_bone_Thumb3.rotation * Quaternion.Euler(l_angle_bone_Thumb3);
        l_hand_Thumb2.rotation = l_bone_Thumb2.rotation * Quaternion.Euler(l_angle_bone_Thumb2);
        l_hand_Thumb1.rotation = l_bone_Thumb1.rotation * Quaternion.Euler(l_angle_bone_Thumb1);
        //l_hand_Thumb0.rotation = l_bone_Thumb0.rotation * Quaternion.Euler(l_angle_bone_Thumb0);
        l_hand_Index3.rotation = l_bone_Index3.rotation * Quaternion.Euler(l_angle_bone_Index3);
        l_hand_Index2.rotation = l_bone_Index2.rotation * Quaternion.Euler(l_angle_bone_Index2);
        l_hand_Index1.rotation = l_bone_Index1.rotation * Quaternion.Euler(l_angle_bone_Index1);
        l_hand_Middle3.rotation = l_bone_Middle3.rotation * Quaternion.Euler(l_angle_bone_Middle3);
        l_hand_Middle2.rotation = l_bone_Middle2.rotation * Quaternion.Euler(l_angle_bone_Middle2);
        l_hand_Middle1.rotation = l_bone_Middle1.rotation * Quaternion.Euler(l_angle_bone_Middle1);
        l_hand_Ring3.rotation = l_bone_Ring3.rotation * Quaternion.Euler(l_angle_bone_Ring3);
        l_hand_Ring2.rotation = l_bone_Ring2.rotation * Quaternion.Euler(l_angle_bone_Ring2);
        l_hand_Ring1.rotation = l_bone_Ring1.rotation * Quaternion.Euler(l_angle_bone_Ring1);
        l_hand_Pinky3.rotation = l_bone_Pinky3.rotation * Quaternion.Euler(l_angle_bone_Pinky3);
        l_hand_Pinky2.rotation = l_bone_Pinky2.rotation * Quaternion.Euler(l_angle_bone_Pinky2);
        l_hand_Pinky1.rotation = l_bone_Pinky1.rotation * Quaternion.Euler(l_angle_bone_Pinky1);
        l_hand_Pinky0.rotation = l_bone_Pinky0.rotation * Quaternion.Euler(l_angle_bone_Pinky0);

        Debug.Log("よばれた");
    }

    private void rightHand(){
        // OVRSkeleton の Bones プロパティを使って、全ての関節の情報を取得
        IList<OVRBone> bones = OVRrightHand.Bones;
        if(bones.Count <20 ) return;
        Debug.Log(bones.Count);
        // var r_bone_Thumb3 = bones[(int)OVRSkeleton.BoneId.Hand_Thumb3];
        // var r_bone_Thumb2 = bones[(int)OVRSkeleton.BoneId.Hand_Thumb2];
        // var r_bone_Thumb1 = bones[(int)OVRSkeleton.BoneId.Hand_Thumb1];
        // var r_bone_Thumb0 = bones[(int)OVRSkeleton.BoneId.Hand_Thumb0];
        // var r_bone_Index3 = bones[(int)OVRSkeleton.BoneId.Hand_Index3];
        // var r_bone_Index2 = bones[(int)OVRSkeleton.BoneId.Hand_Index2];
        // var r_bone_Index1 = bones[(int)OVRSkeleton.BoneId.Hand_Index1];
        // var r_bone_Middle3 = bones[(int)OVRSkeleton.BoneId.Hand_Middle3];
        // var r_bone_Middle2 = bones[(int)OVRSkeleton.BoneId.Hand_Middle2];
        // var r_bone_Middle1 = bones[(int)OVRSkeleton.BoneId.Hand_Middle1];
        // var r_bone_Ring3 = bones[(int)OVRSkeleton.BoneId.Hand_Ring3];
        // var r_bone_Ring2 = bones[(int)OVRSkeleton.BoneId.Hand_Ring2];
        // var r_bone_Ring1 = bones[(int)OVRSkeleton.BoneId.Hand_Ring1];
        // var r_bone_Pinky3 = bones[(int)OVRSkeleton.BoneId.Hand_Pinky3];
        // var r_bone_Pinky2 = bones[(int)OVRSkeleton.BoneId.Hand_Pinky2];
        // var r_bone_Pinky1 = bones[(int)OVRSkeleton.BoneId.Hand_Pinky1];
        // var r_bone_Pinky0 = bones[(int)OVRSkeleton.BoneId.Hand_Pinky0];

        
        
        // Debug.Log($"Bone: {bone_Thumb3.Id}, Position: {bone_Thumb3.Transform.position}, Rotation: {bone_Thumb3.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Thumb2.Id}, Position: {bone_Thumb2.Transform.position}, Rotation: {bone_Thumb2.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Thumb1.Id}, Position: {bone_Thumb1.Transform.position}, Rotation: {bone_Thumb1.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Thumb0.Id}, Position: {bone_Thumb0.Transform.position}, Rotation: {bone_Thumb0.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Index3.Id}, Position: {bone_Index3.Transform.position}, Rotation: {bone_Index3.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Index2.Id}, Position: {bone_Index2.Transform.position}, Rotation: {bone_Index2.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Index1.Id}, Position: {bone_Index1.Transform.position}, Rotation: {bone_Index1.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Middle3.Id}, Position: {bone_Middle3.Transform.position}, Rotation: {bone_Middle3.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Middle2.Id}, Position: {bone_Middle2.Transform.position}, Rotation: {bone_Middle2.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Middle1.Id}, Position: {bone_Middle1.Transform.position}, Rotation: {bone_Middle1.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Ring3.Id}, Position: {bone_Ring3.Transform.position}, Rotation: {bone_Ring3.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Ring2.Id}, Position: {bone_Ring2.Transform.position}, Rotation: {bone_Ring2.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Ring1.Id}, Position: {bone_Ring1.Transform.position}, Rotation: {bone_Ring1.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Pinky3.Id}, Position: {bone_Pinky3.Transform.position}, Rotation: {bone_Pinky0.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Pinky2.Id}, Position: {bone_Pinky2.Transform.position}, Rotation: {bone_Pinky1.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Pinky1.Id}, Position: {bone_Pinky1.Transform.position}, Rotation: {bone_Pinky2.Transform.rotation}");
        // Debug.Log($"Bone: {bone_Pinky0.Id}, Position: {bone_Pinky0.Transform.position}, Rotation: {bone_Pinky3.Transform.rotation}");

        r_hand_Thumb3.rotation = r_bone_Thumb3.rotation * Quaternion.Euler(r_angle_bone_Thumb3);
        r_hand_Thumb2.rotation = r_bone_Thumb2.rotation * Quaternion.Euler(r_angle_bone_Thumb2);
        r_hand_Thumb1.rotation = r_bone_Thumb1.rotation * Quaternion.Euler(r_angle_bone_Thumb1);
        //r_hand_Thumb0.rotation = r_bone_Thumb0.rotation * Quaternion.Euler(r_angle_bone_Thumb0);
        r_hand_Index3.rotation = r_bone_Index3.rotation * Quaternion.Euler(r_angle_bone_Index3);
        r_hand_Index2.rotation = r_bone_Index2.rotation * Quaternion.Euler(r_angle_bone_Index2);
        r_hand_Index1.rotation = r_bone_Index1.rotation * Quaternion.Euler(r_angle_bone_Index1);
        r_hand_Middle3.rotation = r_bone_Middle3.rotation * Quaternion.Euler(r_angle_bone_Middle3);
        r_hand_Middle2.rotation = r_bone_Middle2.rotation * Quaternion.Euler(r_angle_bone_Middle2);
        r_hand_Middle1.rotation = r_bone_Middle1.rotation * Quaternion.Euler(r_angle_bone_Middle1);
        r_hand_Ring3.rotation = r_bone_Ring3.rotation * Quaternion.Euler(r_angle_bone_Ring3);
        r_hand_Ring2.rotation = r_bone_Ring2.rotation * Quaternion.Euler(r_angle_bone_Ring2);
        r_hand_Ring1.rotation = r_bone_Ring1.rotation * Quaternion.Euler(r_angle_bone_Ring1);
        r_hand_Pinky3.rotation = r_bone_Pinky3.rotation * Quaternion.Euler(r_angle_bone_Pinky3);;
        r_hand_Pinky2.rotation = r_bone_Pinky2.rotation * Quaternion.Euler(r_angle_bone_Pinky2);;
        r_hand_Pinky1.rotation = r_bone_Pinky1.rotation * Quaternion.Euler(r_angle_bone_Pinky1);;
        // r_hand_Pinky0.rotation = r_bone_Pinky0.rotation * Quaternion.Euler(r_angle_bone_Pinky0);;

        Debug.Log("よばれた");
    }
}
