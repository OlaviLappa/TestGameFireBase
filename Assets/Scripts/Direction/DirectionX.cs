using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionX : MonoBehaviour
{
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.TryGetComponent(out ObjectManipulation objectManipulation))
            objectManipulation.ChangeDirectionX();
    }
}
