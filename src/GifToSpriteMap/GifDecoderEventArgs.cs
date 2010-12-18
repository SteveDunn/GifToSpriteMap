using System ;

namespace GifToSpriteMap.NGif
{
	public class GifDecoderEventArgs
		: EventArgs
	{
		readonly GifFrame _frame;
		readonly int _frameNumber ;
		readonly int _frameCount ;

		public int FrameNumber
		{
			get { return _frameNumber ; }
		}

		public int FrameCount
		{
			get { return _frameCount ; }
		}

		public GifDecoderEventArgs(GifFrame frame, int frameNumber, int frameCount )
		{
			_frame = frame;
			_frameNumber = frameNumber ;
			_frameCount = frameCount ;
		}

		public GifFrame Frame
		{
			get { return _frame; }
		}
	}
}