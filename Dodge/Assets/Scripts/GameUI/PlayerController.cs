using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] float m_fMoveSpeed = 0;
	Rigidbody m_MyRigidbody = null;

	[HideInInspector] public bool m_bDie = false;

	private void Start()
	{
		m_MyRigidbody = GetComponent<Rigidbody>();
	}

	public void Initializ()
	{
		m_bDie = false;
	}

	void Update()
    {
        
    }

	void FixedUpdate()
	{
		GameScene m_GameScene = GameMng.Inst.m_GameScene;
		if (m_GameScene.m_bStart && !m_bDie)
		{
			float hor = Input.GetAxis("Horizontal");
			float ver = Input.GetAxis("Vertical");
			
			Vector3 pos = transform.position;
			
			pos.x += hor * Time.deltaTime * m_fMoveSpeed;
			pos.z += ver * Time.deltaTime * m_fMoveSpeed;
			
			transform.position = pos;
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Bullet")
		{
			GameScene kGameScene = GameMng.Inst.m_GameScene;
			m_bDie = true;
			kGameScene.m_BattleFSM.SetResultState();
		}
	}
}
