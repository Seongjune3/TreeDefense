using UnityEngine;

public class SliderPositionAutoSetter : MonoBehaviour
{
    [SerializeField]
    private Vector3 distance = Vector3.down * 20.0f;
    private Transform tragetTransform;
    private RectTransform rectTransform;

    public void Setup(Transform target)
    {
        tragetTransform = target;

        rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        if (tragetTransform == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 screenPositon = Camera.main.WorldToScreenPoint(tragetTransform.position);

        rectTransform.position = screenPositon + distance;
    }
}
