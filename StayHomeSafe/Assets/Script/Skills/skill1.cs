﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill1 : MonoBehaviour
{
    public float speed = 5f;
    public PlayerController playerController;
    public ConvertToInfector convertToInfector;

    public AudioSource source;
    public AudioClip useSkill;
    public bool skillCD;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        playerController = GetComponentInParent<PlayerController>();
        convertToInfector = GetComponentInParent<ConvertToInfector>();
        playerController.speed = 5f ;
    }

    // Update is called once per frame
    void Update()
    {
        if (skillCD == false)
        {
            if (Input.GetKeyDown(playerController.skill))
            {
                source.PlayOneShot(useSkill);
                skillCD = true;
                convertToInfector.anim.SetTrigger("TurnAround");
                convertToInfector.skillTime = 15f;

                StartCoroutine(SkillCD());
            }
        }
    }



    IEnumerator SkillCD()
    {
        yield return new WaitForSeconds(15);
        skillCD = false;

    }




}
