﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private Animator a;
	private bool playerMoving;
	private Vector2 lastMove;

	void Start () {
		a=GetComponent<Animator>();
	}

	void Update () {

		playerMoving=false;

		if(Input.GetAxisRaw("Horizontal")>0.5f || Input.GetAxisRaw("Horizontal")<-0.5f){
			transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal")*moveSpeed*Time.deltaTime,0f,0f));
			playerMoving=true;
			lastMove=new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
		}
		if(Input.GetAxisRaw("Vertical")>0.5f || Input.GetAxisRaw("Vertical")<-0.5f){
			transform.Translate(new Vector3(0f,Input.GetAxisRaw("Vertical")*moveSpeed*Time.deltaTime,0f));
			playerMoving=true;
			lastMove=new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		}

		a.SetFloat("MoveX",Input.GetAxisRaw("Horizontal"));
		a.SetFloat("MoveY",Input.GetAxisRaw("Vertical"));
		a.SetBool("PlayerMoving",playerMoving);
		a.SetFloat("LastMoveX",lastMove.x);
		a.SetFloat("LastMoveY",lastMove.y);
	}
}
