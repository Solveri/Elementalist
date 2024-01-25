using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]float time = 0;
    [SerializeField] PlayerAnimationManager AnimationManager;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (InputManagers.instance.Presses>3)
        {
            InputManagers.instance.RestPress();
        }
        RestAttackAfterIdle();
        

     

    }
    private void RestAttackAfterIdle()
    {
        //start looking for the first attack
        // and check how much tine has passed after it
        /* if 2 seconds has passed and he didn't pressed again then we rest the presses timer
         * if ihe pressed again then we rest the timer to check if 2 second has passed
         */
        
        if (InputManagers.instance.Presses > 0) {
            int currentClicks = InputManagers.instance.Presses;
            time += Time.deltaTime;
            if (time >= 2 )
            {
                if (currentClicks == InputManagers.instance.Presses) 
                {
                  
                    InputManagers.instance.RestPress();
                    AnimationManager.ForceOutOfAttack();

                    time = 0;
                }
                else
                {
                    
                    return;
                }
            }
        }

    }

}
