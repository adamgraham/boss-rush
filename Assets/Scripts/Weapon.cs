﻿using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
	public float cooldown;

	public AudioClip[] primaryAttackSounds;

	protected Timer _cooldownTimer;

	public virtual void Start()
	{
		SetCooldown( cooldown );
	}

	public virtual void Update()
	{
		_cooldownTimer.Update();
	}

	public virtual void PerformPrimaryAttack() { }

	public virtual void PerformSecondaryAttack() { }

	public void PlayPrimarySound()
	{
		if ( primaryAttackSounds.Length > 0 )
		{
			audio.clip = primaryAttackSounds[Random.Range( 0, primaryAttackSounds.Length )];
			audio.Play();
		}
	}

	public bool IsOnCooldown
	{
		get
		{
			return !_cooldownTimer.IsComplete();
		}
	}

	public void SetCooldown( float newCooldown )
	{
		Debug.Log( "Setting cooldown to " + newCooldown );
		_cooldownTimer = new Timer( newCooldown, 1 );

		// the timer has to be started now because we need it to be in a "complete" state
		// until it is in a "complete" state, attacks might not work since it is considered on cooldown
		_cooldownTimer.Start();
	}
}
