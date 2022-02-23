using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bullet_Damage = 10f;
    void Start()
    {
        StartCoroutine(Destroy_Timer());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * 50f * Time.deltaTime);
    }

    private IEnumerator Destroy_Timer()
    {
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Module"))
        {
            collision.GetComponent<Module>().Update_Module_HP(bullet_Damage);
            Destroy(this.gameObject);
        }
    }
}
