using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0F;

    [SerializeField]
    private Transform target;

    private void Awake()
    {
        if (!target) target = FindObjectOfType<Character>().transform;//если забыли перенести таргет
    }

    private void Update()
    {
        Vector3 position = target.position; position.z = -10.0F;// чтобы камера видила изображение..
        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
    }
}
