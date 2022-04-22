using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //CubePrefab��ground�ɏՓ˂����特��炷�B
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CubePrefabTag")
        {
            GetComponent<AudioSource>().Play();
        }
        if (collision.gameObject.tag == "groundTag")
        {
            GetComponent<AudioSource>().Play();
        }
    }

    //�L���[�u�̈ړ����x
    private float speed = -12;

    //���ňʒu
    private float deadLine = -10;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�L���[�u���ړ�������
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //��ʂ̊O�ɏo����j������
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }


}
