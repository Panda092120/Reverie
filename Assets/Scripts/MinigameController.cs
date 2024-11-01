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
    public int count = 0;



    public GameState State;

    public void Begin()
    {
        State = GameState.START;
        StartCoroutine(SetupGame());
    }

    IEnumerator SetupGame()
    {
        count = 0;
        var minigameNum = Random.Range(1, 3);
        if(minigameNum == 1)
        {
           Minigame = Instantiate(BulletHell);
           BulletHellScript = Minigame.GetComponent<ShootersShoot>();

        }
        else if(minigameNum == 2)
        {
            Minigame = Instantiate(LinePress);
            LinePressScript = Minigame.GetComponent<circleMove>();
            yield return new WaitForSeconds(4.5f);
            count = LinePressScript.count;
            Debug.Log(count);
        }
        
    }

}
