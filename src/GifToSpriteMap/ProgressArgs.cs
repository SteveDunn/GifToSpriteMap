using System ;
using System.Drawing ;

namespace GifToSpriteMap
{
	public class ProgressArgs
		:EventArgs
	{
		ProgressEvent _progressEvent ;
		string _message ;
		Image _image ;

		public ProgressArgs( ProgressEvent progressEvent,
			string message,
			Image image )
		{
			_progressEvent = progressEvent ;
			_message = message ;
			_image = image ;
		}

		public ProgressEvent ProgressEvent
		{
			get { return _progressEvent ; }
		}

		public string Message
		{
			get { return _message ; }
		}

		public Image Image
		{
			get { return _image ; }
		}
	}
}