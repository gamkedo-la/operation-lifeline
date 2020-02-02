using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
	void TakeDamage(int damage);
	void Die();
	bool GetInvulnerability();
	void SetInvulnerability(bool isInvulnerable);
	MaterialType GetMaterialType();
} 