using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Examples.Archery;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject bow;
    public GameObject arrow;

    private VRTK_ControllerEvents rightControllerEvents;
    private VRTK_InteractUse rightUse;
    private VRTK_InteractGrab rightGrab;
    private VRTK_InteractTouch rightTouch;


    // Start is called before the first frame update
    void Start()
    {
        rightControllerEvents = GetComponent<VRTK_ControllerEvents>();
        rightControllerEvents.TriggerPressed += DoTriggerPressed;

        rightUse = GetComponent<VRTK_InteractUse>();
        rightGrab = GetComponent<VRTK_InteractGrab>();
        rightTouch = GetComponent<VRTK_InteractTouch>();

    }

    private void DoTriggerPressed(object sender, ControllerInteractionEventArgs e)
    {
        if (CheckHasArrow() || CheckBowHasArrow())
            return;
        else
        {
            rightGrab.ForceRelease();

            if (rightUse.IsUseButtonPressed())
            {
                GameObject newArrow = Instantiate(arrow);
                rightTouch.ForceTouch(newArrow);
                rightGrab.AttemptGrab();
                rightUse.AttemptUse();

            }
        }
    }

    private bool CheckHasArrow()
    {
        return rightGrab.GetGrabbedObject() != null;
    }

    private bool CheckBowHasArrow()
    {
        BowAim bowAim = bow.GetComponent<BowAim>();
        return bowAim.HasArrow();
    }


}
