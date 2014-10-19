﻿using UnityEngine;
using System.Collections;

public class SpiderTankInitialState : SpiderTankState
{
	public EnemySpawner spawner;
	public int initialMininionCount;

	public override void Awake()
	{
		base.Awake();

		spawner.RegisterEnemyCountCallback( new EnemySpawner.EnemyCountChange( MinionCountChange ) );
	}

	void OnEnable()
	{
		spawner.enabled = true;
		spawner.Spawn( initialMininionCount );
	}

	public void MinionCountChange( int count )
	{
		if ( enabled && count == 0 )
		{
			enabled = false;
			spawner.enabled = false;

			spiderTank.fleeState.returnState = spiderTank.basicState;
			spiderTank.fleeState.enabled = true;
		}
	}
}
