using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class AnimalAttack : MonoBehaviour
{
    public AnimalSight animalSight;
    public GameObject playerInRange = null;
    public GameObject herbivoreInRange = null;

    /*
    private void OnTriggerEnter(Collider other)
    {
        VRTK_PlayerObject playerObject = other.GetComponent<VRTK_PlayerObject>();
        if (playerObject != null && playerObject.objectType == VRTK_PlayerObject.ObjectTypes.Collider)
        {
            playerInRange = other.gameObject;
            return;
        }

        AnimalBehaviour animalBehaviour = other.GetComponent<AnimalBehaviour>();
        if (animalBehaviour != null && animalBehaviour.animalCategory == AnimalBehaviour.AnimalCategory.HERBIVORE)
        {
            herbivoreInRange = other.gameObject;
            return;
        }

    }
    */

    private void OnTriggerStay(Collider other)
    {

        VRTK_PlayerObject playerObject = other.GetComponent<VRTK_PlayerObject>();
        if (playerObject != null && playerObject.objectType == VRTK_PlayerObject.ObjectTypes.Collider)
        {
            playerInRange = other.gameObject;
            return;
        }

        AnimalBehaviour animalBehaviour = other.GetComponent<AnimalBehaviour>();
        if (animalBehaviour != null && animalBehaviour.animalCategory == AnimalBehaviour.AnimalCategory.HERBIVORE)
        {
            if (other.GetComponentInChildren<AnimalHealth>().IsDead())
                herbivoreInRange = null;
            else
                herbivoreInRange = other.gameObject;
            return;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        VRTK_PlayerObject playerObject = other.GetComponent<VRTK_PlayerObject>();
        if (playerObject != null && playerObject.objectType == VRTK_PlayerObject.ObjectTypes.Collider)
        {
            playerInRange = null;
            return;
        }

        AnimalBehaviour animalBehaviour = other.GetComponent<AnimalBehaviour>();
        if (animalBehaviour != null && animalBehaviour.animalCategory == AnimalBehaviour.AnimalCategory.HERBIVORE)
        {
            herbivoreInRange = null;
            return;
        }

    }

}
