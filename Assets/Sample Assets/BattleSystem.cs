using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

	public GameObject playerPrefab;
	public GameObject enemyPrefab;

	public Transform playerBattleStation;
	public Transform enemyBattleStation;

	Unit playerUnit;
	Unit enemyUnit;

	public Text dialogueText;

	public BattleHUD playerHUD;
	public BattleHUD enemyHUD;

	public BattleState state;

	public Button attackButton;
	public Button reasonButton;
	public Button ItemButton;
	public Button RunButton;

	public int count;
	public bool WinLoss;

	MinigameController minigameController;

	// Start is called before the first frame update
	void Start()
	{
		state = BattleState.START;
		StartCoroutine(SetupBattle());
	}

	IEnumerator SetupBattle()
	{
		GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
		playerUnit = playerGO.GetComponent<Unit>();
		minigameController = FindObjectOfType<MinigameController>();

		GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
		enemyUnit = enemyGO.GetComponent<Unit>();

		dialogueText.text = enemyUnit.unitName + " approaches...";

		playerHUD.SetHUD(playerUnit);
		enemyHUD.SetHUD(enemyUnit);

		yield return new WaitForSeconds(2f);

		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}

	IEnumerator PlayerAttack(int attackType)
	{
		
		if (attackType == 1)
			dialogueText.text = "You try to reason with " + enemyUnit.unitName;
		else
			dialogueText.text = "You try to shove with " + enemyUnit.unitName;

		attackButton.enabled = false;
		reasonButton.enabled = false;
		//yield return new WaitForSeconds(1f);
		
		bool isDead;
		minigameController.Begin();
		yield return new WaitForSeconds(5.5f);
		if(minigameController.State == GameState.WON)
        {
			int critChance = Random.Range(0, 50);
			if (critChance <= playerUnit.luck)
			{
				dialogueText.text = " You lands a crit!";
				isDead = enemyUnit.TakeDamage(playerUnit.damage * 2, attackType);
			}
			else
				isDead = enemyUnit.TakeDamage(playerUnit.damage, attackType);

			enemyHUD.SetHP(enemyUnit.currentHP);
			dialogueText.text = "The attack is successful!";

			yield return new WaitForSeconds(2f);

			if (isDead)
			{
				state = BattleState.WON;
				EndBattle();
			}
			else
			{
				state = BattleState.ENEMYTURN;
				StartCoroutine(EnemyTurn());
			}
		} else
        {
			dialogueText.text = "You missed!";
			yield return new WaitForSeconds(2f);
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}


		
	}

	IEnumerator EnemyTurn()
	{
		dialogueText.text = enemyUnit.unitName + " attacks!";

		yield return new WaitForSeconds(1f);
		bool isDead;
		int critChance = Random.Range(0, 50);
		if (critChance <= playerUnit.luck)
		{
			dialogueText.text = enemyUnit.unitName + " lands a crit!";
			isDead = playerUnit.TakeDamage(enemyUnit.damage * 2, enemyUnit.attackType);
		}
		else
			isDead = playerUnit.TakeDamage(enemyUnit.damage, enemyUnit.attackType);

		playerHUD.SetHP(playerUnit.currentHP);

		yield return new WaitForSeconds(1f);

		if (isDead)
		{
			state = BattleState.LOST;
			EndBattle();
		}
		else
		{
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}

	}

	void EndBattle() //add battle rewards here
	{
		if (state == BattleState.WON)
		{
			dialogueText.text = "You won the battle!";
		}
		else if (state == BattleState.LOST)
		{
			dialogueText.text = "You were defeated.";
		}
		GoToPreviousScene();
	}

	void PlayerTurn()
	{
		dialogueText.text = "Choose an action:";
		attackButton.enabled = true;
		reasonButton.enabled = true;
	}

	IEnumerator PlayerHeal()
	{
		playerUnit.Heal(5);

		playerHUD.SetHP(playerUnit.currentHP);
		dialogueText.text = "You feel renewed strength!";

		yield return new WaitForSeconds(2f);

		state = BattleState.ENEMYTURN;
		StartCoroutine(EnemyTurn());
	}

	public void OnPhysAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerAttack(0));
	}

	public void OnIntAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerAttack(1));
	}

	public void OnHealButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerHeal());
	}

	public void GoToPreviousScene()
	{
		SceneStateManager sceneStateManager = FindObjectOfType<SceneStateManager>();

		if (sceneStateManager != null)
		{
			sceneStateManager.LoadPreviousScene();
		}
		else
		{
			Debug.Log("Scene state manager is null");
		}
	}
	
}
