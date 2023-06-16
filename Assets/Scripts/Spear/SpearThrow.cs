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
    private Slider throwUI;


    private float chargeSpeed;
    private float launchForce;
    private string shootButton;
    private bool thrown = false;
    public bool canThrow;
    private float minLaunchForce = 5f;
    private float maxLaunchForce = 25f;
    private float minChargeTime;
    public float maxChargeTime = .75f;

    private InputManager input;
    private AimTest aim;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        chargeSpeed = (maxLaunchForce) / maxChargeTime;
        minChargeTime = chargeSpeed * minLaunchForce;
       
        input = GetComponent<InputManager>();
        aim = GetComponentInChildren<AimTest>();
        animator = GetComponent<Animator>();

        throwUI.maxValue = maxLaunchForce;
        
    }

    // Update is called once per frame
    void Update()
    {
        shootButton = input.GetShootButton();
        animator.SetBool("Throwing", true);

        Rotate();
        if(canThrow){
            
            if(launchForce >= maxLaunchForce && !thrown)
            {
                launchForce = maxLaunchForce;
                Throw();
            }
            else if(Input.GetButtonDown(shootButton))
            {
                thrown = false;
                launchForce = 0.0f;
                Debug.Log(shootButton);
                animator.SetBool("Charging", true);
                throwUI.gameObject.SetActive(true);
            }
            else if(Input.GetButton(shootButton) && !thrown)
            {
                launchForce += Time.deltaTime * chargeSpeed;
                
                // slider update
                throwUI.value = launchForce;
            }
            else if (Input.GetButtonUp(shootButton) && !thrown)
            {
                if(launchForce > minLaunchForce)
                {
                    Throw();
                }
                else
                {
                    resetUI();
                    launchForce = minLaunchForce;
                    animator.SetBool("Charging", false);
                    // shouldnt play the throw animation here, not sure why it does
                }
            }
        }

        animator.SetBool("Has Weapon", canThrow);
    }

    void Throw()
    {
        thrown = true;
        animator.SetBool("Throwing", true);
        animator.SetBool("Charging", false);
        AudioManager.Instance.Play("SpearThrow");

        GameObject spearInstance = Instantiate(spear, throwTransform.position, throwTransform.rotation);
        Rigidbody2D spearRB = spearInstance.GetComponent<Rigidbody2D>();
        spearRB.AddForce(throwTransform.up * launchForce, ForceMode2D.Impulse);
        
        launchForce = minLaunchForce;

        resetUI();
        canThrow = false;
    }

    private void Rotate()
    {
        Vector2 aimDirection = aim.MousePos() - throwTransform.transform.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        throwTransform.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void resetUI()
    {
        throwUI.value = minLaunchForce;
        throwUI.gameObject.SetActive(false);
    }

}
