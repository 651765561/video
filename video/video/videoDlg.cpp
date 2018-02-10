
// videoDlg.cpp : ʵ���ļ�
//

#include "stdafx.h"
#include "video.h"
#include "videoDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

#include "ClientMediaSDKInterface.h"


// ����Ӧ�ó��򡰹��ڡ��˵���� CAboutDlg �Ի���

class CAboutDlg : public CDialogEx
{
public:
	CAboutDlg();

// �Ի�������
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ʵ��
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


// CvideoDlg �Ի���




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


// CvideoDlg ��Ϣ�������

BOOL CvideoDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// ��������...���˵�����ӵ�ϵͳ�˵��С�

	// IDM_ABOUTBOX ������ϵͳ���Χ�ڡ�
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

	// ���ô˶Ի����ͼ�ꡣ��Ӧ�ó��������ڲ��ǶԻ���ʱ����ܽ��Զ�
	//  ִ�д˲���
	SetIcon(m_hIcon, TRUE);			// ���ô�ͼ��
	SetIcon(m_hIcon, FALSE);		// ����Сͼ��

	// TODO: �ڴ���Ӷ���ĳ�ʼ������
	int val=client_media_init(NULL);
	return TRUE;  // ���ǽ��������õ��ؼ������򷵻� TRUE
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

// �����Ի��������С����ť������Ҫ����Ĵ���
//  �����Ƹ�ͼ�ꡣ����ʹ���ĵ�/��ͼģ�͵� MFC Ӧ�ó���
//  �⽫�ɿ���Զ���ɡ�

void CvideoDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // ���ڻ��Ƶ��豸������

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// ʹͼ���ڹ����������о���
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// ����ͼ��
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

//���û��϶���С������ʱϵͳ���ô˺���ȡ�ù��
//��ʾ��
HCURSOR CvideoDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}




void CvideoDlg::play_media()
{
//	void* hWnd;
	//char rtsp_url[] = "rtsp://192.168.0.226/20000000001320000001";	//��˾��
	//char rtsp_url[] = "rtsp://192.168.0.226/20000000001320000002";	//�żҸۺ�
	char rtsp_url[] = "rtsp://192.168.0.226/34020000001320397400";	//����
	CWnd *pWnd = GetDlgItem(IDC_STATIC_PLAY); // ȡ�ÿؼ���ָ��	IDC_STOP
	HWND hWnd = pWnd->GetSafeHwnd();  // ȡ�ÿؼ��ľ��	
	sessionID = client_media_realtime_open(rtsp_url, hWnd, NULL, -1);
	client_media_realtime_play(sessionID);
}

void CvideoDlg::OnDestroy()
{
	CDialogEx::OnDestroy();

	// TODO: �ڴ˴������Ϣ����������
	client_media_release();
}

void CvideoDlg::OnBnClickedPlay()
{
	// TODO: �ڴ���ӿؼ�֪ͨ����������
	play_media();

}

void CvideoDlg::OnBnClickedStop()
{
	// TODO: �ڴ���ӿؼ�֪ͨ����������
	client_media_realtime_close(sessionID);
}


void CvideoDlg::OnBnClickedPlay2()
{
	// TODO: �ڴ���ӿؼ�֪ͨ����������
}


void CvideoDlg::OnBnClickedStop2()
{
	// TODO: �ڴ���ӿؼ�֪ͨ����������
}


void CvideoDlg::createProHead(char* proBuf,int callInfo,int Cseq,int contentLength)
{
	sprintf(proBuf,"REGISTER sip:340200002000000001@172.21.103.163 SIP/2.0\r\nCall-ID: abedreg;branch\r\nCall-Info:%d\r\nContent-Type: \
				   Application/xml\r\nExpires: 3600\r\nCseq:%d REGISTER\r\nFrom: <sip:340200003000000001@172.21.103.163>;tag=123\r\nMax-Forwards: 70\r\nTo: \
				   <sip:340200002000000001@172.21.103.163>\r\nContent-Length:%d\r\n\r\n",callInfo,Cseq,contentLength);
}
