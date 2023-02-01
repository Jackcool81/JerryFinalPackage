using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

	public GameObject playerPrefab;
	public GameObject [] EnimiesPrefabs;

	public Transform playerBattleStation;
	public Transform[] enemyBattleStations; 
	
	Unit playerUnit;
	List<Unit> enemies = new List<Unit>();
	
	int enemyturn = 0;

	GameObject[] enemyGos;

	int deadCount = 0;

	public Text dialogueText;

	public BattleHUD playerHUD;
	public List <BattleHUD> EnemiesHUD = new List <BattleHUD> ();

	int temp = 0;

	public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
		state = BattleState.START;
		StartCoroutine(SetupBattle());
    }

	IEnumerator SetupBattle()
	{
		///Setting up our player
		GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
		playerUnit = playerGO.GetComponent<Unit>();

		//Setting up our enemies
		//1
		GameObject enemyGO = Instantiate(EnimiesPrefabs[0], enemyBattleStations[0]);
		enemies.Add(enemyGO.GetComponent<Unit>());

		//2
		GameObject enemyGo1 = Instantiate(EnimiesPrefabs[1], enemyBattleStations[1]);
		enemies.Add(enemyGo1.GetComponent<Unit>());

		//3
		GameObject enemyGO2 = Instantiate(EnimiesPrefabs[2], enemyBattleStations[2]);
		enemies.Add(enemyGO2.GetComponent<Unit>());

		//4
		GameObject enemyGo3 = Instantiate(EnimiesPrefabs[3], enemyBattleStations[3]);
		enemies.Add(enemyGo3.GetComponent<Unit>());

		//Doing the intro text
		dialogueText.text = "A grand bunch of rocks approaches...";

		//Setting up HUDS
		playerHUD.SetHUD(playerUnit);
		for(int i = 0; i < EnemiesHUD.Count; i++)
		{
			EnemiesHUD[i].SetHUD(enemies[i]);
		}

		yield return new WaitForSeconds(2f);

		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}

	IEnumerator PlayerAttack(int enemyNum)
	{
		bool isDead = enemies[enemyNum].TakeDamage(playerUnit.damage);
		
		EnemiesHUD[enemyNum].SetHP(enemies[enemyNum].currentHP); //need to make an array based system 
		
		
		dialogueText.text = "The attack is successful!";

		yield return new WaitForSeconds(2f);

		if(isDead)
		{
			enemies[enemyNum].isDead();
			 for(int i = 0; i < enemies.Count; i++) { //4 for now until I can get the array working 
			 	if (enemies[i].dead == true) {
					deadCount++;
			 	}
			 }
			print(deadCount);
			if (deadCount >= 4) {
				state = BattleState.WON;
				EndBattle();
			}
			else {
				deadCount = 0;
				
				StartCoroutine(EnemyTurnI(enemies[0]));

			}
		} 
		else
		{
			state = BattleState.ENEMYTURN;
			
			StartCoroutine(EnemyTurnI(enemies[0]));

		}
	}

	IEnumerator EnemyTurnI(Unit i)
	{
bool isDead = false;
		enemyturn++;
		//If curent enemy is dead, goto the next one
		if (i.dead == true) 
		{
			print(i.name + "is dead");
			i.hasGone = true; //Skipping their turn cauuse they died
		}
		else {
			//make them attack our player
			print(enemyturn);
			dialogueText.text = i.unitName + " attacks!";
			yield return new WaitForSeconds(1f);
			isDead = playerUnit.TakeDamage(i.damage); //save our damage into isDead to see if the player died
			i.hasGone = true; //since the enemy attacked this turn, they have GONE
			playerHUD.SetHP(playerUnit.currentHP);
			print(playerUnit.currentHP);
			yield return new WaitForSeconds(1f);
		}
		
		if(isDead) //if Player dies lose game
		{
			state = BattleState.LOST; //
			EndBattle();
		} 
		else { //if player doesn't die start the next alive enemy  turn
			if(enemies[0].hasGone == false && enemies[0].dead == false)
				{
					StartCoroutine(EnemyTurnI(enemies[0]));
				}
				else if(enemies[1].hasGone == false && enemies[1].dead == false)
				{
					StartCoroutine(EnemyTurnI(enemies[1]));
				}
				else if(enemies[2].hasGone == false && enemies[2].dead == false)
				{
					StartCoroutine(EnemyTurnI(enemies[2]));
				}
				else if(enemies[3].hasGone == false && enemies[3].dead == false)
				{
					StartCoroutine(EnemyTurnI(enemies[3]));
				}
				else//If All enemies have gone
				{
					for (int x = 0; x < enemies.Count; x++) 
					{
						if (enemies[x].dead == false) //if our enemy isn't dead
						{
							enemies[x].hasGone = false; //reset their turn
						}
					}
					state = BattleState.PLAYERTURN; //then start the player turn
					enemyturn = 0;
					PlayerTurn();
				}
			}
	}

	void EndBattle()
	{
		if(state == BattleState.WON)
		{
			dialogueText.text = "You won the battle!";
			StartCoroutine(battleDone());
		} else if (state == BattleState.LOST)
		{
			dialogueText.text = "You were defeated.";
			StartCoroutine(battleLost());
		}
	}

IEnumerator battleDone() 
	{
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene(1);
	}

IEnumerator battleLost() 
	{
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene(0);
	}


	void PlayerTurn()
	{
		dialogueText.text = "Choose an action:";
	}

	IEnumerator PlayerHeal()
	{
		playerUnit.Heal(325);

		playerHUD.SetHP(playerUnit.currentHP);
		dialogueText.text = "You feel renewed strength!";

		yield return new WaitForSeconds(2f);

		state = BattleState.ENEMYTURN;
		StartCoroutine(EnemyTurnI(enemies[0]));
	}

	public void OnAttackButton()
	{
		//0th enemy
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerAttack(0));
	}

	public void OnAttackButton1()
	{
		//1st enemy
		if (state != BattleState.PLAYERTURN)
			return;
		//startCoroutine with an integer that is the index of whatever enemy
		//you attacked?
		StartCoroutine(PlayerAttack(1));
	}

	public void OnAttackButton2()
	{
		//2nd enemy
		if (state != BattleState.PLAYERTURN)
			return;
		//startCoroutine with an integer that is the index of whatever enemy
		//you attacked?
		StartCoroutine(PlayerAttack(2));
	}

	public void OnAttackButton3()
	{
		//4th enemy
		if (state != BattleState.PLAYERTURN)
			return;
		//startCoroutine with an integer that is the index of whatever enemy
		//you attacked?
		StartCoroutine(PlayerAttack(3));
	}


	public void OnHealButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerHeal());
	}
}
