using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState { START, WON, LOST }
public class MinigameController : MonoBehaviour
{
    public GameObject BulletHell;
    ShootersShoot BulletHellScript;

    public GameObject LinePress;
    GameObject Minigame;
    circleMove LinePressScript;
    public int count;



    public GameState State;

    public void Begin()
    {
        count = 0;
        State = GameState.START;
        StartCoroutine(SetupGame());
    }

    IEnumerator SetupGame()
    {
        count = 0;
        var minigameNum = Random.Range(1, 3);
        State = GameState.WON;
        minigameNum = 1;
        if(minigameNum == 1)
        {
           Minigame = Instantiate(BulletHell);
           BulletHellScript = Minigame.GetComponent<ShootersShoot>();
           yield return new WaitForSeconds(4.9f);
            if (count >= 3)
                State = GameState.LOST;
           Debug.Log("here");

        }
        else if(minigameNum == 2)
        {
            State = GameState.LOST;
            Minigame = Instantiate(LinePress);
            LinePressScript = Minigame.GetComponentInChildren<circleMove>();
            yield return new WaitForSeconds(4.9f);
            Debug.Log(count);
            if (count >= 5)
                State = GameState.WON;
            Debug.Log("here");
        }
        
        
    }
    

}
