using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HubUI : MonoBehaviour
{
	public StartMenuDlg m_StartMenuDlg = null;
	public ResultGameDlg m_ResultGameDlg = null;

	[SerializeField] Text m_txtCount = null;
	[SerializeField] GameObject m_ReadyUI = null;
	[SerializeField] GameObject m_ResultUI = null;
	float m_fTime = 0;
	int m_nCount = 3;

	void Start()
    {
		Initializ();
	}

	public void Initializ()
	{
		m_txtCount.text = m_nCount.ToString();
	}

	void Update()
    {

	}

	public void StartReadyCount()
	{
		ShowUIText();
		StartCoroutine("ReadyCount", 1.0f);
	}

	IEnumerator ReadyCount(float fDeley)
	{
		int nCount = 3;
		while (nCount >= 0)
		{
			if (nCount == 0)
				m_txtCount.text = "Start";
			else
				m_txtCount.text = nCount.ToString();

			--nCount;

			yield return new WaitForSeconds(fDeley);
		}
		if(nCount < 0)
		{
			NotShowUIText();
			GameScene kGameScene = GameMng.Inst.m_GameScene;
			kGameScene.m_BattleFSM.SetGameState();
			kGameScene.m_bStart = true;
		}
	}

	void ShowUIText()
	{
		m_ReadyUI.SetActive(true);
	}
	void NotShowUIText()
	{
		m_ReadyUI.SetActive(false);
	}

	void ShowResultUI()
	{
		m_ResultUI.SetActive(true);
	}
	void NotShowResultUI()
	{
		m_ResultUI.SetActive(false);
	}

	public void PlayerDie()
	{
		GameScene m_GameScene = GameMng.Inst.m_GameScene;
		if (m_GameScene.m_GameUI.m_PlayerController.m_bDie)
		{
			ShowResultUI();
		}
	}
}
