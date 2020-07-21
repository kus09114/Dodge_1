using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuDlg : MonoBehaviour
{
	[SerializeField] Button m_btnStart = null;
	[SerializeField] Button m_btnOption = null;

	[SerializeField] GameObject m_OptionPopup = null;

	public bool m_bOnStart = false;

	void Start()
	{
		m_btnStart.onClick.AddListener(OnClick_Start);
		m_btnOption.onClick.AddListener(OnClick_Option);
	}

	void Initializ()
	{

	}

	void Update()
    {
        
    }

	public void OpenUI()
	{
		gameObject.SetActive(true);
	}
	public void CloseUI()
	{
		gameObject.SetActive(false);
	}

	public void OnClick_Start()
	{
		GameScene kGamescene = GameMng.Inst.m_GameScene;

		kGamescene.m_BattleFSM.SetReadyState();
		CloseUI();
	}

	public void OnClick_Option()
	{
		m_OptionPopup.SetActive(true);
	}
}
