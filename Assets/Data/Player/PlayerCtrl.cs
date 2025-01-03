using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations.Rigging;
using UnityEngine;

public class PlayerCtrl : MyBehaviour
{
    [SerializeField] protected vThirdPersonController thirdPersonCtrl;
    public vThirdPersonController ThirdPersonController => thirdPersonCtrl;

    [SerializeField] protected vThirdPersonCamera thirdPersonCamera;
    public vThirdPersonCamera ThirdPersonCamera => thirdPersonCamera;

    [SerializeField] protected PlayerCrosshair crosshairPointer;
    public PlayerCrosshair CrosshairPointer => crosshairPointer;

    [SerializeField] protected Rig aimingRig;
    public Rig AimingRig => aimingRig;

    [SerializeField] protected WeaponsManager weapons;
    public WeaponsManager Weapons => weapons;
    [SerializeField] protected Animator animator;
    public Animator Animator => animator;
    [SerializeField] protected PlayerMana playerMana;
    public PlayerMana PlayerMana => playerMana;
    [SerializeField] protected PlayerDamageReceiver playerDamageReceiver;
    public PlayerDamageReceiver PlayerDamageReceiver => playerDamageReceiver;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadThirdPersonCtrl();
        this.LoadThirdPersonCamera();
        this.LoadCrosshairPointer();
        this.LoadAimingRig();
        this.LoadWeapons();
        this.LoadAnimator();
        this.LoadPlayerMana();
        this.LoadPlayerDamageReceiver();
    }
    protected virtual void LoadPlayerDamageReceiver()
    {
        if (this.playerDamageReceiver != null) return;
        this.playerDamageReceiver = GetComponentInChildren<PlayerDamageReceiver>();
        Debug.Log(transform.name + ": LoadPlayerDamageReceiver", gameObject);
    }
    protected virtual void LoadPlayerMana()
    {
        if (this.playerMana != null) return;
        this.playerMana = GetComponentInChildren<PlayerMana>();
        Debug.Log(transform.name + ": LoadPlayerMana", gameObject);
    }
    protected virtual void LoadWeapons()
    {
        if (this.weapons != null) return;
        this.weapons = GetComponentInChildren<WeaponsManager>();
        Debug.Log(transform.name + ": LoadWeapons", gameObject);
    }

    protected virtual void LoadAimingRig()
    {
        if (this.aimingRig != null) return;
        this.aimingRig = transform.Find("Model").Find("AimingRig").GetComponent<Rig>();
        Debug.Log(transform.name + ": LoadAimingRig", gameObject);
    }

    protected virtual void LoadCrosshairPointer()
    {
        if (this.crosshairPointer != null) return;
        this.crosshairPointer = GetComponentInChildren<PlayerCrosshair>();
        Debug.Log(transform.name + ": LoadCrosshairPointer", gameObject);
    }

    protected virtual void LoadThirdPersonCtrl()
    {
        if (this.thirdPersonCtrl != null) return;
        this.thirdPersonCtrl = GetComponent<vThirdPersonController>();
        Debug.Log(transform.name + ": LoadThirPersonCtrl", gameObject);
    }
    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.Find("Model").GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    protected virtual void LoadThirdPersonCamera()
    {
        if (this.thirdPersonCamera != null) return;
        this.thirdPersonCamera = GameObject.FindAnyObjectByType<vThirdPersonCamera>();
        this.thirdPersonCamera.rightOffset = 0.6f;
        this.thirdPersonCamera.defaultDistance = 1.2f;
        this.thirdPersonCamera.height = 1.8f;
        this.thirdPersonCamera.yMinLimit = -40f;
        this.thirdPersonCamera.yMaxLimit = 40f;
        Debug.Log(transform.name + ": LoadThirdPersonCamera", gameObject);
    }
}
