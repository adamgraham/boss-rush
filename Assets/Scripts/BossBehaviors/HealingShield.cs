﻿using UnityEngine;
using System.Collections;

public class HealingShield : MonoBehaviour
{
	public Color fullHealthColor;
	public Color noHealthColor;

	private HealthSystem _health;
	private Renderer _renderer;

	void Awake()
	{
		_renderer = renderer;
		_health = GetComponent<HealthSystem>();
		_health.RegisterHealthCallback( HealthChangeCallback );
	}

	void OnEnable()
	{
		_health.Reset();
		_renderer.material.color = fullHealthColor;
	}

	void HealthChangeCallback( HealthSystem health, float change )
	{
		if ( _health.alive )
		{
			_renderer.material.color = Color.Lerp( noHealthColor, fullHealthColor, _health.percent );
		}
	}
}
