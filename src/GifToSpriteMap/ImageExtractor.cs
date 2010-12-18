using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using GifToSpriteMap.NGif;

namespace GifToSpriteMap
{
	public class ImageExtractor
	{
		public event ImageExtractionHandler Progress;

		public Image Extract(string[] pathsToAnimatedGif, DestinationShape destinationShape)
		{
			var streams = new Stream[pathsToAnimatedGif.Length];

			for (int i = 0; i < pathsToAnimatedGif.Length; i++)
			{
				streams[i] = File.OpenRead(pathsToAnimatedGif[i]);
			}

			return Extract(streams, destinationShape);
		}

		public Image Extract(
		  Stream[] streamsToAnimatedGif,
		  DestinationShape destinationShape)
		{
			var images = new List<Image>();

			int count = 0;
			
			foreach (Stream stream in streamsToAnimatedGif)
			{
				if (Progress != null)
				{
					var bs = new byte[stream.Length];
					stream.Read(bs, 0, bs.Length);
					stream.Seek(0, SeekOrigin.Begin);

					Image img = Image.FromStream(new MemoryStream(bs));
					var args =
					  new ProgressArgs(
									  ProgressEvent.StartingToProcessSourceImage,
									  string.Format(
										@"Processing image {0} of {1} - file: {2}",
										count, streamsToAnimatedGif.Length, stream),
										img);
					Progress(this, args);
				}

				List<Frame> frames = getFrames(stream);
				
				Image i = writeFramesToImage(frames, destinationShape);
				
				images.Add(i);
				
				count++;
			}

			return combineImages(images, destinationShape);
		}

		static Image combineImages(List<Image> images,
		  DestinationShape destinationShape)
		{
			var destPoint = new Point(0, 0);
			Size destSize = getCombinedExtent(images, destinationShape);

			Image outputImage = new Bitmap(destSize.Width, destSize.Height);

			Graphics g = Graphics.FromImage(outputImage);

			foreach (Image i in images)
			{
				g.DrawImage(i, destPoint);

				if (destinationShape == DestinationShape.Wide)
					destPoint.X += i.Width;
				else
					destPoint.Y += i.Height;
			}

			g.Save();

			return outputImage;

		}

		public Image Extract(string pathToAnimatedGif, DestinationShape destinationShape)
		{
			return Extract(new[] { pathToAnimatedGif }, destinationShape);
		}

		public Image Extract(Stream streamOfAnimatedGif, DestinationShape destinationShape)
		{
			return Extract(new[] { streamOfAnimatedGif }, destinationShape);
		}

		static Size getCombinedExtent(IList<Image> images, DestinationShape destinationShape)
		{
			if (images.Count == 1)
			{
				return new Size(images[0].Width, images[0].Height);
			}

			var destPoint = new Point(0, 0);

			int maxWidth = 0;
			int maxHeight = 0;

			foreach (Image i in images)
			{
				if (destinationShape == DestinationShape.Wide)
					destPoint.X += i.Width;
				else
					destPoint.Y += i.Height;

				maxWidth = Math.Max(maxWidth, destPoint.X + i.Size.Width);
				maxHeight = Math.Max(maxHeight, destPoint.Y + i.Size.Height);
			}

			return new Size(maxWidth, maxHeight);

		}

		static Image writeFramesToImage(List<Frame> frames, DestinationShape shape)
		{
			Size frameSize = frames[0].Size;

			int imageWidth = frames.Count * frameSize.Width;
			int imageHeight = frameSize.Height;

			var squareSize = (int)Math.Sqrt(frames.Count);
			
			if (shape == DestinationShape.Square)
			{
				imageWidth = squareSize * frameSize.Width;
				int ySize = squareSize;
				if (frames.Count % squareSize != 0)
					++ySize;
				imageHeight = (ySize + 1) * frameSize.Height;
			}

			if (shape == DestinationShape.Tall)
			{
				imageWidth = frameSize.Width;
				imageHeight = frameSize.Height * frames.Count;
			}


			Image outputImage =
			  new Bitmap(imageWidth, imageHeight);

			Graphics graphics = Graphics.FromImage(outputImage);

			var destPoint = new Point(0, 0);

			for (int i = 0; i < frames.Count; i++)
			{
				Frame currentFrame = frames[i];

				graphics.DrawImage(currentFrame.Image, destPoint);

				if (shape == DestinationShape.Square)
				{
					destPoint.X += frameSize.Width;

					if ((i + 1) % squareSize == 0)
					{
						destPoint.X = 0;
						destPoint.Y += frameSize.Height;
					}
				}


				if (shape == DestinationShape.Wide)
					destPoint.X += currentFrame.Size.Width;
				if (shape == DestinationShape.Tall)
					destPoint.Y += currentFrame.Size.Height;
			}


			graphics.Save();

			return outputImage;
		}

		List<Frame> getFrames(Stream stream)
		{
			var gifDecoder = new GifDecoder();
			gifDecoder.FrameAdded += gifDecoderFrameAdded;
			gifDecoder.Read(stream);

			int frameCount = gifDecoder.GetFrameCount();
			Size frameSize = gifDecoder.GetFrameSize();
			
			var frames = new List<Frame>(frameCount);

			for (int i = 0; i < frameCount; i++)
			{
				Image frame = gifDecoder.GetFrame(i);
				frames.Add(new Frame(frameSize, frame));
			}
			
			return frames;
		}

		void gifDecoderFrameAdded(object sender, GifDecoderEventArgs e)
		{
			if (Progress == null)
			{
				return;
			}

			Progress(this, new ProgressArgs(
							  ProgressEvent.StartingToProcessFrameFromSourceImage,
							  string.Format(@"Frame {0} added.", e.FrameNumber),
							  e.Frame.image.Clone() as Image));
		}
	}
}