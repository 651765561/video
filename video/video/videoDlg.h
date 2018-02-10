
// videoDlg.h : 头文件
//

#pragma once


// CvideoDlg 对话框
class CvideoDlg : public CDialogEx
{
// 构造
public:
	CvideoDlg(CWnd* pParent = NULL);	// 标准构造函数

// 对话框数据
	enum { IDD = IDD_VIDEO_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV 支持


// 实现
protected:
	HICON m_hIcon;

	// 生成的消息映射函数
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
