using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadPlayer : MonoBehaviour
{
    private int deadPlayers = 0;
    private int[] DeadPlayerNumber = new int[3];
    static public int[] score = new int[4];
    // Start is called before the first frame update
    void Start()
    {
        DeadPlayerNumber[0] = -1; DeadPlayerNumber[1] = -1; DeadPlayerNumber[2] = -1;
    }

    public void PlayerDied(int playerNumber)
    {
        deadPlayers++;
        if(deadPlayers == 1)
        {
                DeadPlayerNumber[0] = playerNumber;
                Debug.Log(DeadPlayerNumber[0]);
        }
        if(deadPlayers == 2)
        {
            DeadPlayerNumber[1] = playerNumber;
            Debug.Log(DeadPlayerNumber[1]);
        }
        if(deadPlayers == 3)
        {
            DeadPlayerNumber[2] = playerNumber;
            Debug.Log(DeadPlayerNumber[2]);
            Invoke("CheckPlayersDeath", 3f);
        }
    }
    void CheckPlayersDeath()
    {
        if (deadPlayers == 3)
        {

            //1生き残ったら
            if (DeadPlayerNumber[0] != 1 || DeadPlayerNumber[2] != 1 || DeadPlayerNumber[2] != 1)
            {
                score[0]++;
                if (score[0] > 3) score[0] = 1;
                Debug.Log("プレイヤー1の勝利");
            }
            else if (DeadPlayerNumber[0] != 2 || DeadPlayerNumber[2] != 2 || DeadPlayerNumber[2] != 2)
            {
                score[1]++;
                if (score[1] > 3) score[1] = 1;
                Debug.Log("プレイヤー2の勝利");
            }
            else if (DeadPlayerNumber[0] != 3 || DeadPlayerNumber[2] != 3 || DeadPlayerNumber[2] != 3)
            {
                score[2]++;
                if (score[2] > 3) score[2] = 1;
                Debug.Log("プレイヤー3の勝利");
            }
            else
            {
                score[3]++;
                if (score[3] > 3) score[3] = 1;
                Debug.Log("プレイヤー4の勝利");
            }
            

        }
        else
            Debug.Log("引き分け");
    }
}
