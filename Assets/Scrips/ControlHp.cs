using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHp : MonoBehaviour
{
    [SerializeField] UpdateHp UpdateHp;
    float CurrentHp;
    [SerializeField] float MaxHp = 1000f;
    [SerializeField] GameObject sphere1;
    [SerializeField] GameObject sphere2;
    float stepHp;

    private void Start()
    {

        CurrentHp = MaxHp/2;
        UpdateHp.SetUpHP(CurrentHp, MaxHp);

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("play1"))
        {

            PlayMove play1 = sphere1.GetComponent<PlayMove>();
            stepHp = play1.PushStrength;
            //Debug.Log("Applied upward force after exiting collision. " + play1.PushStrength);
            CurrentHp -= stepHp;
            UpdateHp.SetUpHP(CurrentHp, MaxHp);


        }
        if (collision.gameObject.CompareTag("play2"))
        {
            PlayMove play2 = sphere2.GetComponent<PlayMove>();
            stepHp = play2.PushStrength;
            //Debug.Log("Applied upward force after exiting collision2. " + play2.PushStrength);
            CurrentHp += stepHp;
            UpdateHp.SetUpHP(CurrentHp, MaxHp);

        }

    }
}
