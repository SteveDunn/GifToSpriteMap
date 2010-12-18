using System ;
using System.Drawing ;

namespace GifToSpriteMap
{
	public class ProgressArgs
		:EventArgs
	{
		public ProgressArgs( ProgressEvent progressEvent,
			string message,
			Image image )
		{
			ProgressEvent = progressEvent ;
			Message = message ;
			Image = image ;
		}

		public ProgressEvent ProgressEvent
		{
			get ;
			private set ;
		}

		public string Message
		{
			get ;
			private set ;
		}

		public Image Image
		{
			get ;
			private set ;
		}
	}
}