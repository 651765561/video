
// videoDlg.h : ͷ�ļ�
//

#pragma once


// CvideoDlg �Ի���
class CvideoDlg : public CDialogEx
{
// ����
public:
	CvideoDlg(CWnd* pParent = NULL);	// ��׼���캯��

// �Ի�������
	enum { IDD = IDD_VIDEO_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV ֧��


// ʵ��
protected:
	HICON m_hIcon;

	// ���ɵ���Ϣӳ�亯��
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedPlay();
	void play_media(void);

public:
	int sessionID;
	afx_msg void OnBnClickedStop();
	afx_msg void OnDestroy();
	afx_msg void OnBnClickedPlay2();
	afx_msg void OnBnClickedStop2();
	void createProHead(char* proBuf,int callInfo,int Cseq,int contentLength);
};
