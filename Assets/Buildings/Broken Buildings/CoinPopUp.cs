using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPopUp : MonoBehaviour
{
    Animator Coin_Animator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCoinCollected()
    {
        Coin_Animator.SetBool("MineCollect", true);
    }
}
