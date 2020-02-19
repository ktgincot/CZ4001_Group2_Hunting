namespace VRTK.Examples.Archery
{
    using UnityEngine;

    public class ArrowNotch : MonoBehaviour
    {
        private VRTK_InteractableObject interactObject;
        private GameObject arrow;

        private void Start()
        {
            interactObject = GetComponent<VRTK_InteractableObject>();
            arrow = transform.Find("Arrow").gameObject;
        }

        private void OnTriggerEnter(Collider collider)
        {
            BowHandle handle = collider.GetComponentInParent<BowHandle>();
            
            if (handle != null && interactObject != null && handle.aim.IsHeld() && interactObject.IsGrabbed() ) //&& interactObject.IsUsing())
            {
                handle.nock = collider.transform;
                arrow.transform.SetParent(handle.arrowNockingPoint);

                CopyNotchToArrow();

                collider.GetComponentInParent<BowAim>().SetArrow(arrow);
                Destroy(gameObject);
            }
        }

        private void CopyNotchToArrow()
        {
            GameObject notchCopy = Instantiate(gameObject, transform.position, transform.rotation) as GameObject;
            notchCopy.name = name;
            arrow.GetComponent<Arrow>().SetArrowHolder(notchCopy);
            arrow.GetComponent<Arrow>().OnNock();
        }
    }
}