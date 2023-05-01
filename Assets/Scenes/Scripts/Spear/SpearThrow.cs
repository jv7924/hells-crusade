using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpearThrow : MonoBehaviour
{
    [SerializeField]
    private int playerNumber;
    [SerializeField] 
    private GameObject spear;
    [SerializeField]
    private Transform throwTransform;
    [SerializeField]
    private float minLaunchForce = 15f;
    [SerializeField]
    private float maxLaunchForce = 30f;
    [SerializeField]
    private float maxChargeTime = .75f;
    [SerializeField]
    private Slider throwUI;

    private float chargeSpeed;
    private float launchForce;
    private string throwButton;
    private bool thrown = false;
    private bool canThrow;
    
    
    // Start is called before the first frame update
    void Start()
    {
        chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;
        throwButton = "Fire" + playerNumber;
    }

    // Update is called once per frame
    void Update()
    {
        // needs UI update to be added still
        if(launchForce >= maxLaunchForce && !thrown)
        {
            launchForce = maxLaunchForce;
            Throw();
        }
        else if(Input.GetButtonDown(throwButton))
        {
            thrown = false;
            launchForce = minLaunchForce;
        }
        else if(Input.GetButton(throwButton) && !thrown)
        {
            launchForce += Time.deltaTime * chargeSpeed;
            // slider update
        }
        else if (Input.GetButtonUp(throwButton) && !thrown)
        {
            Throw();
        }
    }

    void Throw()
    {
        thrown = true;
        
        GameObject spearInstance = Instantiate(spear, throwTransform.position, throwTransform.rotation);
        Rigidbody2D spearRB = spearInstance.GetComponent<Rigidbody2D>();
        spearRB.AddForce(throwTransform.up * launchForce, ForceMode2D.Impulse);
        
        launchForce = minLaunchForce;
        //canThrow = false;
    }
}
