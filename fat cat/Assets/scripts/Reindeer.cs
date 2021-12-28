using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reindeer : MonoBehaviour
{
    public int damage;
    public float speed;

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("grandma"))
        {
            other.GetComponent<grandma>().health -= damage;
            Debug.Log(other.GetComponent<grandma>().health);
            Destroy(gameObject);
        }
    }
}
