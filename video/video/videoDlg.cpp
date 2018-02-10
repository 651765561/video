
// videoDlg.cpp : 实现文件
//

#include "stdafx.h"
#include "video.h"
#include "videoDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

#include "ClientMediaSDKInterface.h"


// 用于应用程序“关于”菜单项的 CAboutDlg 对话框

class CAboutDlg : public CDialogEx
{
public:
	CAboutDlg();

// 对话框数据
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 实现
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialogEx(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialogEx)
END_MESSAGE_MAP()


// CvideoDlg 对话框




CvideoDlg::CvideoDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(CvideoDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CvideoDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CvideoDlg, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_PLAY, &CvideoDlg::OnBnClickedPlay)
	ON_BN_CLICKED(IDC_STOP, &CvideoDlg::OnBnClickedStop)
	ON_WM_DESTROY()
END_MESSAGE_MAP()


// CvideoDlg 消息处理程序

BOOL CvideoDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// 将“关于...”菜单项添加到系统菜单中。

	// IDM_ABOUTBOX 必须在系统命令范围内。
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		BOOL bNameValid;
		CString strAboutMenu;
		bNameValid = strAboutMenu.LoadString(IDS_ABOUTBOX);
		ASSERT(bNameValid);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// 设置此对话框的图标。当应用程序主窗口不是对话框时，框架将自动
	//  执行此操作
	SetIcon(m_hIcon, TRUE);			// 设置大图标
	SetIcon(m_hIcon, FALSE);		// 设置小图标

	// TODO: 在此添加额外的初始化代码
	int val=client_media_init(NULL);
	return TRUE;  // 除非将焦点设置到控件，否则返回 TRUE
}

void CvideoDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialogEx::OnSysCommand(nID, lParam);
	}
}

// 如果向对话框添加最小化按钮，则需要下面的代码
//  来绘制该图标。对于使用文档/视图模型的 MFC 应用程序，
//  这将由框架自动完成。

void CvideoDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // 用于绘制的设备上下文

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// 使图标在工作区矩形中居中
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// 绘制图标
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

//当用户拖动最小化窗口时系统调用此函数取得光标
//显示。
HCURSOR CvideoDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}




void CvideoDlg::play_media()
{
//	void* hWnd;
	//char rtsp_url[] = "rtsp://192.168.0.226/20000000001320000001";	//公司黑
	//char rtsp_url[] = "rtsp://192.168.0.226/20000000001320000002";	//张家港黑
	char rtsp_url[] = "rtsp://192.168.0.226/34020000001320397400";	//财务
	CWnd *pWnd = GetDlgItem(IDC_STATIC_PLAY); // 取得控件的指针	IDC_STOP
	HWND hWnd = pWnd->GetSafeHwnd();  // 取得控件的句柄	
	sessionID = client_media_realtime_open(rtsp_url, hWnd, NULL, -1);
	client_media_realtime_play(sessionID);
}

void CvideoDlg::OnDestroy()
{
	CDialogEx::OnDestroy();

	// TODO: 在此处添加消息处理程序代码
	client_media_release();
}

void CvideoDlg::OnBnClickedPlay()
{
	// TODO: 在此添加控件通知处理程序代码
	play_media();

}

void CvideoDlg::OnBnClickedStop()
{
	// TODO: 在此添加控件通知处理程序代码
	client_media_realtime_close(sessionID);
}


void CvideoDlg::OnBnClickedPlay2()
{
	// TODO: 在此添加控件通知处理程序代码
}


void CvideoDlg::OnBnClickedStop2()
{
	// TODO: 在此添加控件通知处理程序代码
}


void CvideoDlg::createProHead(char* proBuf,int callInfo,int Cseq,int contentLength)
{
	sprintf(proBuf,"REGISTER sip:340200002000000001@172.21.103.163 SIP/2.0\r\nCall-ID: abedreg;branch\r\nCall-Info:%d\r\nContent-Type: \
				   Application/xml\r\nExpires: 3600\r\nCseq:%d REGISTER\r\nFrom: <sip:340200003000000001@172.21.103.163>;tag=123\r\nMax-Forwards: 70\r\nTo: \
				   <sip:340200002000000001@172.21.103.163>\r\nContent-Length:%d\r\n\r\n",callInfo,Cseq,contentLength);
}
