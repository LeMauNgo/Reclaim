using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThirdPersonCtrl : vThirdPersonController
{
    public virtual void PlayerInit()
    {
        animator = GetComponentInChildren<Animator>();
        animator.updateMode = AnimatorUpdateMode.AnimatePhysics;

        // slides the character through walls and edges
        frictionPhysics = new PhysicMaterial();
        frictionPhysics.name = "frictionPhysics";
        frictionPhysics.staticFriction = .25f;
        frictionPhysics.dynamicFriction = .25f;
        frictionPhysics.frictionCombine = PhysicMaterialCombine.Multiply;

        // prevents the collider from slipping on ramps
        maxFrictionPhysics = new PhysicMaterial();
        maxFrictionPhysics.name = "maxFrictionPhysics";
        maxFrictionPhysics.staticFriction = 1f;
        maxFrictionPhysics.dynamicFriction = 1f;
        maxFrictionPhysics.frictionCombine = PhysicMaterialCombine.Maximum;

        // air physics 
        slippyPhysics = new PhysicMaterial();
        slippyPhysics.name = "slippyPhysics";
        slippyPhysics.staticFriction = 0f;
        slippyPhysics.dynamicFriction = 0f;
        slippyPhysics.frictionCombine = PhysicMaterialCombine.Minimum;

        // rigidbody info
        _rigidbody = GetComponent<Rigidbody>();

        // capsule collider info
        _capsuleCollider = transform.Find("PlayerDamageReceiver").GetComponent<CapsuleCollider>();

        // save your collider preferences 
        colliderCenter = transform.Find("PlayerDamageReceiver").GetComponent<CapsuleCollider>().center;
        colliderRadius = transform.Find("PlayerDamageReceiver").GetComponent<CapsuleCollider>().radius;
        colliderHeight = transform.Find("PlayerDamageReceiver").GetComponent<CapsuleCollider>().height;

        isGrounded = true;
    }
}
