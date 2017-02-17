using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {
    public GameObject MineStone;
    //public GameObject Camera;
    MineStone mineScript;
    CameraShake cameraShake;
    public GameObject PS_Sparks;
    public GameObject PS_Impact;
    Animator animator;
    public AudioClip[] hitSound;
    AudioSource audio;

    void Start () {
        animator = GetComponent<Animator>();
        mineScript = MineStone.GetComponent<MineStone>();
        cameraShake = MineStone.GetComponent<CameraShake>();
        audio = GetComponent<AudioSource>();
	}
	void Update () {
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("Mining", true);
        }
        else
        {
            animator.SetBool("Mining", false);
        }
	}
    void Spark()
    {
        if (mineScript.rayHit != null && mineScript.stones < mineScript.inventorySize )
        {
            audio.clip = hitSound[Random.Range(0, hitSound.Length)];
            audio.Play();
            mineScript.addStones = true;
            Stone stoneHit = mineScript.rayHit;
            if (stoneHit.destroyObject == false)
            {
                mineScript.stones += (int)stoneHit.stonesPerHit * (int)mineScript.pickStonePerHit;
                stoneHit.transform.localScale -= new Vector3(stoneHit.perc * mineScript.pickStonePerHit, stoneHit.perc * mineScript.pickStonePerHit, stoneHit.perc * mineScript.pickStonePerHit);
                stoneHit.amountStones -= stoneHit.stonesPerHit * mineScript.pickStonePerHit;

                Instantiate(PS_Impact, mineScript.hit.point, Quaternion.LookRotation(mineScript.hit.normal));
                Instantiate(PS_Sparks, mineScript.hit.point, Quaternion.LookRotation(mineScript.hit.normal));
                cameraShake.shakeDuration += 0.2f;
            }

            if (stoneHit.amountStones <= 0)
            {
                stoneHit.destroyObject = true;
            }
        }
        else
        {
            mineScript.addStones = false;
        }
    }
}
