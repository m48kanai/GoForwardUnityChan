using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //�A�j���[�V���������邽�߂̃R���|�[�l���g������
    Animator animator;

    //Unity�������ړ�������R���|�[�l���g������i�ǉ��P�j
    Rigidbody2D rigid2D;

    //�n�ʂ̈ʒu
    private float groundLevel = -3.0f;

    //�W�����v�̑��x�����i�ǉ��P�j
    private float dump = 0.8f;

    //�W�����v�̑��x�i�ǉ��P�j
    float jumpVelocity = 20;

    //�Q�[���I�[�o�[�ɂȂ�ʒu�i�ǉ�3�j
    private float deadLine = -9;

    // Start is called before the first frame update
    void Start()
    {
        // �A�j���[�^�̃R���|�[�l���g���擾����
        this.animator = GetComponent<Animator>();

        //Rigidbody2D�̃R���|�[�l���g���擾����i�ǉ�1�P�j
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //����A�j���[�V�������Đ����邽�߂ɁAAnimator�̃p�����[�^�𒲐�����
        this.animator.SetFloat("Horizontal", 1);

        //���n���Ă��邩�ǂ����𒲂ׂ�
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        //�W�����v��Ԃ̂Ƃ��ɂ̓{�����[����0�ɂ���i�ǉ��@Lesson 7Chapter 9.2�j
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        //���n��ԂŃN���b�N���ꂽ�ꍇ�i�ǉ��j
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            //������̗͂�q����i�ǉ��j
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        //�N���b�N����߂��������̑��x����������i�ǉ�2�j
        if(Input.GetMouseButton(0) == false)
        {
            if(this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        //�f�b�h���C���𒴂����ꍇ�Q�[���I�[�o�[�ɂ���i�ǉ�3�j
        if(transform.position.x < this.deadLine)
        {
            //UIController��GameOver�֐����Ăяo���ĉ�ʏ�ɁuGameOver�v�ƕ\������
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            //Unity������j������
            Destroy(gameObject);
        }
    }
}