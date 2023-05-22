using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpearThrow : MonoBehaviour
{
    [SerializeField] 
    private GameObject spear;
    [SerializeField]
    private Transform throwTransform;
    [SerializeField]
    private float minLaunchForce = 15f;
    [SerializeField]
    private float maxLaunchForce = 30f;
    [SerializeField]
    public float maxChargeTime = .75f;
    [SerializeField]
    private GameObject throwUI;
    [SerializeField]
    private Sprite throwUISprite;

    private float chargeSpeed;
    private float launchForce;
    private string shootButton;
    private bool thrown = false;
    public bool canThrow;

    private InputManager input;
    private AimTest aim;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;
        // throwButton = "Fire" + playerNumber;
        input = GetComponent<InputManager>();
        aim = GetComponentInChildren<AimTest>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        shootButton = input.GetShootButton();

        Rotate();
        if(canThrow){
            // needs UI update to be added still
            if(launchForce >= maxLaunchForce && !thrown)
            {
                launchForce = maxLaunchForce;
                Throw();
            }
            else if(Input.GetButtonDown(shootButton))
            {
                thrown = false;
                launchForce = minLaunchForce;
                Debug.Log(shootButton);
            }
            else if(Input.GetButton(shootButton) && !thrown)
            {
                launchForce += Time.deltaTime * chargeSpeed;
                // slider update
            }
            else if (Input.GetButtonUp(shootButton) && !thrown)
            {
                Throw();
            }
        }

        animator.SetBool("Has Weapon", canThrow);
    }

    void Throw()
    {
        thrown = true;
        
        GameObject spearInstance = Instantiate(spear, throwTransform.position, throwTransform.rotation);
        Rigidbody2D spearRB = spearInstance.GetComponent<Rigidbody2D>();
        spearRB.AddForce(throwTransform.up * launchForce, ForceMode2D.Impulse);
        
        launchForce = minLaunchForce;

        // changes spear UI image from yellow (has spear) to white (doesn't have spear)
        if(throwUI != null)
        {
            Image throwImage = throwUI.GetComponent<Image>();
            throwImage.sprite = throwUISprite;
        }
            
        
        canThrow = false;
    }

    private void Rotate()
    {
        Vector2 aimDirection = aim.MousePos() - throwTransform.transform.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        throwTransform.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
