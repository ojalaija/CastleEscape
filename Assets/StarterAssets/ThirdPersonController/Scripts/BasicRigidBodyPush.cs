﻿using UnityEngine;

public class BasicRigidBodyPush : MonoBehaviour
{

    // this script pushes all rigidbodies with tag pushable that the character touches
    float pushPower = 2.0f;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        Rigidbody body = hit.collider.attachedRigidbody;
        Animator _animator = hit.controller.GetComponentInParent<Animator>();

        // no rigidbody
        if (body == null || body.isKinematic)
        {
            return;
        }

        // We dont want to push objects below us
       if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        if (!body.CompareTag("Pushable"))
        {
            return;
        }

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.

        // Apply the push
        body.velocity = pushDir * pushPower;
        _animator.SetBool("IsPushing", true);

    }

}

