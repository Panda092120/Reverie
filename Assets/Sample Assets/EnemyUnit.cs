using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour
{

	public string unitName;
	public int unitLevel;

	public int damage;

	public int maxHP;
	public int currentHP;

	public int intellect; // magic
	public int physical; // strength
	public int intDef; // magic defense
	public int physDef; // strength defense
	public int luck; // crit
	public int attackType; // 0 Phys || 1 Int


	public bool TakeDamage(int dmg, int dmgType)
	{
		// dmgType == 0 (physical) || dmgTpe == 1 (intellect)
		if (dmgType == 0)
			currentHP -= (dmg - physDef);	
		else
			currentHP -= (dmg - intDef);

		if (currentHP <= 0)
			return true;
		else
			return false;
	}

	public void Heal(int amount)
	{
		currentHP += amount;
		if (currentHP > maxHP)
			currentHP = maxHP;
	}

}
