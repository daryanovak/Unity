using UnityEngine;
using System.Collections;

public class Live : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Character character = collider.GetComponent<Character>();

        if (character)
        {
            character.Lives++;
            Destroy(gameObject);
        }
    }
}
