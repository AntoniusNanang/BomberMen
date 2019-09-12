using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Boom_PowUp : MonoBehaviour
{
    public int B_R_C = 0; //爆風変化値
    
   public int Passing (int B_R)
    {
        B_R += B_R_C;
        return B_R;
    }
}
