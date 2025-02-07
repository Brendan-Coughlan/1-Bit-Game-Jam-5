using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private PlayerBackpack playerBackpack;

    private void Awake()
    {
        playerBackpack = GetComponent<PlayerBackpack>();
    }

    void FixedUpdate()
    {
        Vector2 rayOrigin = (Vector2)(transform.position + (transform.up * 0.55f));
        Debug.DrawRay(rayOrigin, transform.up * 1.5f, Color.blue, 0);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, transform.up, 1.5f);
            if (hit.collider != null)
            {
                if (hit.collider.transform.CompareTag("Tree"))
                {
                   /* Debug.DrawRay(rayOrigin, transform.up * 1.5f, Color.red, 0);*/
                    playerBackpack.woodCount++;
                    Destroy(hit.collider.gameObject);
                }
                else if(hit.collider.transform.CompareTag("Campfire"))
                {
                    hit.collider.GetComponent<CampfireController>().AddToFuel(playerBackpack.woodCount);
                    playerBackpack.woodCount = 0;
                }
            }
        }
    }
}
