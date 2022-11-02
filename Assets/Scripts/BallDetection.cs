using UnityEngine;

public class BallDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.TryGetComponent(out ObjectManipulation objectManipulation))
        {
            var ballModelRenderer1 = this.gameObject.GetComponent<Renderer>();
            var ballModelRenderer2 = objectManipulation.GetComponent<Renderer>();

            if (ballModelRenderer1.material.color != ballModelRenderer2.material.color)
            {
                objectManipulation.GetComponent<SphereCollider>().isTrigger = true;
            }
                
            else
            {
                GameUI.OnGlassesChange.Invoke(this, 15);

                Transform childBallObject = this.gameObject.transform.GetChild(0);

                GameObject _electricSfxPrefab = Resources.Load<GameObject>("Effects/CFX2_SparksHit_B Sphere");
                GameObject _electricSfxCopy = Instantiate(_electricSfxPrefab) as GameObject;

                _electricSfxCopy.transform.position = childBallObject.transform.position;
                childBallObject.gameObject.SetActive(true);
            }

            Destroy(objectManipulation.GetComponent<ObjectManipulation>());
        }
    }
}
