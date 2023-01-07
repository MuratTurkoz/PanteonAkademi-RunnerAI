using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    [SerializeField] Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim=GetComponentInChildren<Animator>();
    }
    public void LoseAnimation()
    {
        playerAnim.SetBool("Lose",true);
    }
    public void WinAnimation()
    {
        playerAnim.SetBool("Win", true);
    }

}
