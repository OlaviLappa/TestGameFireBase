using UnityEngine;

public class BallGroupsCreating : MonoBehaviour
{
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.TryGetComponent(out BallDetection ballDetection))
        {
            var ballModelRenderer1 = this.gameObject.transform.GetComponentInParent<Renderer>();
            var ballModelRenderer2 = ballDetection.GetComponent<Renderer>();

            if (ballModelRenderer1.material.color == ballModelRenderer2.material.color)
            {
                obj.gameObject.transform.GetChild(0).gameObject.SetActive(true);

                Object.Destroy(obj.gameObject);
                Object.Destroy(ballModelRenderer1.gameObject);
            }
        }
    }
}
