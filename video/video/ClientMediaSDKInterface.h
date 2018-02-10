
#pragma once
// interface

#ifndef CLIENT_MEDIA_SDK_API_IMPL
#define CLIENT_MEDIA_SDK_API __declspec(dllimport)
#else
#define CLIENT_MEDIA_SDK_API __declspec(dllexport)
#endif


/*
 *	demo:
 *		void EventCallback(int callbackID, int eventType, int status)
 *		{
 *			printf("callbackID=%d, eventType=%d, status=%d\n", callbackID, eventType, status);
 *		}
 *		
 *		void play_media()
 *		{
 *			client_media_init();
 *			char rtsp_url[] = "rtsp://127.0.0.1/123";
 *			int sessionID = client_media_open(rtsp_url, EventCallback, 1);
 *
 *			client_media_play(sessionID, -1, -1, -1);
 *			
 *			client_media_close(sessionID);
 *			client_media_release();
 *		}
 *		
 *		
 *		
 */


#ifdef __cplusplus
extern "C" {
#endif


/*
enum EventNotify_EventType{
	emEvent_FileLen = 0,	// the total length of file, this is callback when call client_media_open
	emEvent_PlayPos,		// status unit is millisecond
	emEvent_PlayFinished,	// has play to the end position of the file.
	enEvent_PlayTimeout,	// not use yet

	emEvent_DownloadPos,		// position of download in milliseconds increment
	emEvent_DownloadSecondOffset,	// second offset from the begin of the file
	emEvent_DownloadFileLength, // the size of file which has downloaded in bytes.
	emEvent_DownloadFinished,	// finished the download
	emEvent_DownloadTimeout,	// not use yet
};
*/

/*
 *	event callback function define details:
 *	
 *	eventType	status
 *	1			file total seconds
 *	2			current position in second
 */
typedef void (__stdcall* ClientMedia_EventNotifyCallback)(int callbackID, int eventType, int status);

/*
// Global Initialize
CLIENT_MEDIA_SDK_API int __stdcall client_media_init(void* hWnd);
CLIENT_MEDIA_SDK_API int __stdcall client_media_release();


// RealTime API
CLIENT_MEDIA_SDK_API int __stdcall client_media_realtime_open(const char* url, void* hWnd, 
															  ClientMedia_EventNotifyCallback callback, int callbackID);
CLIENT_MEDIA_SDK_API int __stdcall client_media_realtime_close(int sessionID);
CLIENT_MEDIA_SDK_API int __stdcall client_media_realtime_play(int sessionID);
CLIENT_MEDIA_SDK_API int __stdcall client_media_realtime_capture(int sessionID, const char* picturePath);


// Record Playback API
CLIENT_MEDIA_SDK_API int __stdcall client_media_record_open(const char* url, void* hWnd, 
															ClientMedia_EventNotifyCallback callback, int callbackID);
CLIENT_MEDIA_SDK_API int __stdcall client_media_record_close(int sessionID);
CLIENT_MEDIA_SDK_API int __stdcall client_media_record_play(int sessionID, int startPos, 
															int endPos, float scale );
CLIENT_MEDIA_SDK_API int __stdcall client_media_record_play_frame(int sessionID, int startPos);
CLIENT_MEDIA_SDK_API int __stdcall client_media_record_pause(int sessionID);
CLIENT_MEDIA_SDK_API int __stdcall client_media_record_capture(int sessionID, const char* picturePath);


// Download API
CLIENT_MEDIA_SDK_API int __stdcall client_media_download_open(const char* url, const char* filePath, 
															  ClientMedia_EventNotifyCallback callback, int callbackID);
CLIENT_MEDIA_SDK_API int __stdcall client_media_download_start(int sessionID, int nStartSecond, int nSeconds);
CLIENT_MEDIA_SDK_API int __stdcall client_media_download_pause(int sessionID);
CLIENT_MEDIA_SDK_API int __stdcall client_media_download_resume(int sessionID);
CLIENT_MEDIA_SDK_API int __stdcall client_media_download_close(int sessionID);


// Error handler
CLIENT_MEDIA_SDK_API int __stdcall client_media_get_last_error(int sessionID);
*/


//////////////////////////////////////////////////////////////////////////////////////
// definitions


//////////////////////////////Global Initialize//////////////////////////////////////
/*
 *	Functions: 
 *		Initialize the dynamic library, client_media_init(void*) must be called before using the APIs and
 *	client_media_release() should be called before unload the library.
 *	parameters:
 *		@hWnd: the global window handle, D3D need it to create device. if this is NULL, the library will
 *			use multiple devices. if this is not NULL, the library will use one device and SwapChain display
 *			technology. Multiple Devices Display Mode use more threads, but more compatibility. 
 *			SwapChain Display Mode use less threads, but may be less compatibility.
 *			
 */
CLIENT_MEDIA_SDK_API int __stdcall client_media_init(void* hWnd);

/*
 *	Functions:
 *		Release resource.
 *	Return:
 *		-1 - failed, >=0 - success.
 */
CLIENT_MEDIA_SDK_API int __stdcall client_media_release();


/*
 *	Functions:
 *		network cache, to process network jitter
 */
CLIENT_MEDIA_SDK_API int __stdcall client_media_config(int cacheTime);


//////////////////////////////Real Time//////////////////////////////////////
/*
 *	Functions:
 *		Real Time API. Call this function to open a real time stream.
 *	parameters:
 *		@url: rtsp url, example: rtsp://127.0.0.1/FileStream/1
 *		@hWnd: handle of window which will display video
 *		@callback: event callback function
 *		@callbackID: call @callback with this value.
 *	return:
 *		return id of the real time session. if -1 returned, error happened.
 */
CLIENT_MEDIA_SDK_API int __stdcall client_media_realtime_open(const char* url, void* hWnd, 
															  ClientMedia_EventNotifyCallback callback, int callbackID);

/*
 *	Functions:
 *		Close real time stream.
 *	parameters:
 *		@sessionID: id of the real time session, returned by API client_media_realtime_open.
 *	return:
 *		-1 - failed, >= 0 - success.
 */
CLIENT_MEDIA_SDK_API int __stdcall client_media_realtime_close(int sessionID);

/*
 *	Function:
 *		play real time video.
 *	Parameters:
 *		@sessionID: id of the real time session, returned by API client_media_realtime_open.
 *	Return:
 *		-1 - failed, >=0 - success.
 */
CLIENT_MEDIA_SDK_API int __stdcall client_media_realtime_play(int sessionID);

/*
 *	Function:
 *		capture video frame showed on.
 *	Parameters:
 *		@sessionID: id of the real time session, returned by API client_media_realtime_open.
 *		@picturePath: full path which capture picture will store.
 *	Return:
 *		-1 - failed, >=0 - success.
 */
CLIENT_MEDIA_SDK_API int __stdcall client_media_realtime_capture(int sessionID, const char* picturePath);

/*
 *	Function:
 *		start record real time stream into file.
 *	Parameters:
 *		@sessionID: id of the real time session, returned by API client_media_realtime_open.
 *		@szStrategy: zero end string, strategy to record. 
 *					Format: 
 *						<record_strategy>
 *							<!-- file name will like c:\record\channel_20140104_162430>
 *							<file_name>C:\record\channel</file_name>
 *							<!-- default - 300M, -1 - always record -->
 *							<file_max_size unit="mb">300</file_max_size>
 *							<file_store_format>flv</file_store_format>
 *						</record_strategy>
 *										
 *	Return:
 *		< 0 - failed, >= 0 - success.
 */
CLIENT_MEDIA_SDK_API int __stdcall client_media_realtime_start_record(int sessionID, const char* szStrategy);

/*
 *	Function:
 *		stop record real time stream.
 *	Parameters:
 *		@sessionID: id of the real time session, returned by API client_media_realtime_open.
 *	Return:
 *		< 0 - failed, >= 0 - success.
 */
CLIENT_MEDIA_SDK_API int __stdcall client_media_realtime_stop_record(int sessionID);



//////////////////////////////Record Playback//////////////////////////////////////

/*
 *	Function:
 *		open record media session.
 *	Parameters:
 *		@url: rtsp url, example: rtsp://127.0.0.1/FileStream/1
 *		@hWnd: handle of window which will display video
 *		@callback: event callback function.
 *		@callbackID: call @callback with this value.
 */
CLIENT_MEDIA_SDK_API int __stdcall client_media_record_open(const char* url, void* hWnd, 
															ClientMedia_EventNotifyCallback callback, int callbackID);

/*
 *	Function:
 *		close record media session.
 *	Parameters:
 *		@sessionID: id of record media session, returned by API client_media_record_open.
 *	Return:
 *		-1 - failed, >=0 - success.
 */
CLIENT_MEDIA_SDK_API int __stdcall client_media_record_close(int sessionID);

/*
 *	Function:
 *		play record media session.
 *	Parameters:
 *		@sessionID: id of the media session, returned by API client_media_record_open.
 *		@startPos: offset in seconds from begin of the record file. Video will start play on this position.
 *				if -1 or 0, start play from begin of the file.
 *		@endPos: offset in seconds from begin of the record file. Video will stop play on this position. 
 *				if -1, play until the end of the file.
 *		@scale: the scale of the speed playing video. default: 1.0f
 *	Return:
 *		-1 - failed, 0 - success
 */
CLIENT_MEDIA_SDK_API int __stdcall client_media_record_play(int sessionID, int startPos, 
															int endPos, float scale );

/*
 *	Function:
 *		play one record media frame
 *	Parameters:
 *		@sessionID: id of the media session, returned by API client_media_record_open.
 *		@startPos: offset in seconds from begin of the file. Key frame will be found in this position.
 *	Return:
 *		-1 - failed, >=0 - success.
 */
CLIENT_MEDIA_SDK_API int __stdcall client_media_record_play_frame(int sessionID, int startPos);

/*
 *	Function:
 *		pause record media session.
 *	Parameters:
 *		@sessionID: id of the media session, returned by API client_media_record_open.
 *	Return:
 *		-1 - failed, >= 0 - success.
 */
CLIENT_MEDIA_SDK_API int __stdcall client_media_record_pause(int sessionID);

/*
 *	Function:
 *		capture video frame.
 *	Parameters:
 *		@sessionID: id of the media session, returned by API client_media_record_open.
 *		@picturePath: path to save picture captured.
 *	Return:
 *		-1 - failed, >=0 - success.
 */
CLIENT_MEDIA_SDK_API int __stdcall client_media_record_capture(int sessionID, const char* picturePath);

//////////////////////////////Download//////////////////////////////////////
/*
 *	Function:
 *		open download session. It will save video data in flv format
 *	Parameters:
 *		@url: format, file_name@ip:port
 *		@filePath: path to saved record data downloaded.
 *		@callback: event callback function.
 *		@callbackID: call @callback with this value.
 */
CLIENT_MEDIA_SDK_API int __stdcall client_media_download_open(const char* url, const char* filePath, 
															  ClientMedia_EventNotifyCallback callback, int callbackID);

/*
 *	Function:
 *		start download
 *	Parameters:
 *		@sessionID: id of the download session, returned by API client_media_download_open
 *		@nStartSecond: offset in seconds from begin for the file. Start download from this position.
 *		@nSeconds: total seconds will be downloaded. if 0, download all file.
 *	Return:
 *		-1 - failed, >=0 - success.
 */
CLIENT_MEDIA_SDK_API int __stdcall client_media_download_start(int sessionID, int nStartSecond, int nSeconds);

/*
 *	Function:
 *		pause download
 *	Parameters:
 *		@sessionID: id of the download session, returned by API client_media_download_open
 *	Return:
 *		-1 - failed, >=0 - success.
 */
CLIENT_MEDIA_SDK_API int __stdcall client_media_download_pause(int sessionID);

/*
 *	Function:
 *		resume download
 *	Parameters:
 *		@sessionID: id of the download session, returned by API client_media_download_open
 *	Return:
 *		-1 - failed, >= 0 - success.
 */
CLIENT_MEDIA_SDK_API int __stdcall client_media_download_resume(int sessionID);

/*
 *	Function: 
 *		close download session
 *	Parameters:
 *		@sessionID: id of the download session, returned by API client_media_download_open
 *	Return:
 *		-1 - failed, >=0 - success.
 */
CLIENT_MEDIA_SDK_API int __stdcall client_media_download_close(int sessionID);

//////////////////////////////Error handle//////////////////////////////////////
/*
 *	Function:
 *		get last error from media session.
 *	Parameters:
 *		@sessionID: id of the download session, returned by API client_media_download_open
 *	Return:
 *		error number.
 */
#define CLIENT_MEDIA_ERROR_NOT_SUPPORTED	-2
CLIENT_MEDIA_SDK_API int __stdcall client_media_get_last_error(int sessionID);

#ifdef __cplusplus
}
#endif