using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YunaCollider : MonoBehaviour
{
    [SerializeField] private State toState;
    [SerializeField] List<string> instantlyKillingTags;

    private Yuna character;
    private Transform characterTransform;

    private void Start()
    {
        instantlyKillingTags = new List<string>();
        character = GetComponent<Yuna>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Collider hitCollider = hit.collider;
        if (instantlyKillingTags.Contains(hitCollider.tag))
        {

        }
        else
        {
            float delta = hitCollider.transform.localScale.y - transform.position.y + transform.localScale.y * 0.75f;
            character.currentState.Hit(delta, hitCollider);
        }
    }
}
