﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
	public float speed = 150.0f; 			// in world units
	public float maxDistance = 500.0f;		// in world units
	public float maxTime = 8.0f; 			// in seconds

	private float _distanceTraveled;
	private float _elapsedTime; 
	
	void Update() 
	{
		float deltaSpeed = Time.deltaTime * speed;

		// move the projectile forward according to its rotation
		this.transform.Translate( Vector3.forward * deltaSpeed );

		// update properties to check if the projectile should be destroyed
		_distanceTraveled += deltaSpeed;
		_elapsedTime += Time.deltaTime;

		// if the projectile has traveled farther than its max distance, it is destroyed
		if ( _distanceTraveled > maxDistance ) 
		{
			Destroy( this.gameObject );
		}

		// if the projectile has lasted longer the its max life time, it is destroyed
		if ( _elapsedTime > maxTime ) 
		{
			Destroy( this.gameObject );
		}
	}
}