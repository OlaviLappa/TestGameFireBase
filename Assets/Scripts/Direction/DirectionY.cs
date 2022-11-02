using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionY : MonoBehaviour
{
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.TryGetComponent(out ObjectManipulation objectManipulation))
            objectManipulation.ChangeDirectionY();
    }
}
