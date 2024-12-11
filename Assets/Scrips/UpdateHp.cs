using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHp : MonoBehaviour
{
  
    [SerializeField] Image barHp;

    public void SetUpHP(float CurrentHp, float MaxHp)
    {
        barHp.fillAmount = CurrentHp/MaxHp;
    }


}
