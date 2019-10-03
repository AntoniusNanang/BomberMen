using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlayer : MonoBehaviour
{
    private int deadPlayers = 0;
    private int[] DeadPlayerNumber = new int[3]; 
    // Start is called before the first frame update
    void Start()
    {
        DeadPlayerNumber[0] = -1; DeadPlayerNumber[1] = -1; DeadPlayerNumber[2] = -1;
    }

    public void PlayerDied(int playerNumber)
    {
        deadPlayers++;
        if(deadPlayers == 3)
        {
            for (int i = 0; i < DeadPlayerNumber.Length; i++)
            {
                DeadPlayerNumber[i] = playerNumber;
                Invoke("CheckPlayersDeath", 3f);
            }
        }
    }
    void CheckPlayersDeath()
    {
        if (deadPlayers == 3)
        {
            for (int i = 0; i < DeadPlayerNumber.Length; i++)
            {
                //1生き残ったら
                if (DeadPlayerNumber[i] != 1)
                {
                    Debug.Log("プレイヤー1の勝利");
                }
                else if (DeadPlayerNumber[i] != 2)
                {
                    Debug.Log("プレイヤー2の勝利");
                }
                else if (DeadPlayerNumber[i] != 3)
                {
                    Debug.Log("プレイヤー3の勝利");
                }
                else
                {
                    Debug.Log("プレイヤー4の勝利");
                }
            }

        }
        else
            Debug.Log("引き分け");
    }
}
