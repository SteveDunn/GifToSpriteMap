using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using MbUnit.Framework;

namespace GifToSpriteMap
{
	[TestFixture]
	public class Tests
	{
		[Test]
		public void TestCombinedImage()
		{
			var ie = new ImageExtractor();
			var streams = new Stream[2];
			Assembly a = Assembly.GetExecutingAssembly();

			streams[0] = a.GetManifestResourceStream(@"GifToSpriteMap.TestImage1.gif");
			streams[1] = a.GetManifestResourceStream(@"GifToSpriteMap.TestImage2.gif");

			var image = ie.Extract(streams, DestinationShape.Square);
			Assert.AreEqual(237, image.Width);
			Assert.AreEqual(504, image.Height);
		}

		[Test]
		public void TestImage1()
		{
			var imageExtractor = new ImageExtractor();
			Assembly assembly = Assembly.GetExecutingAssembly();
			
			using (
			  Stream s = assembly.GetManifestResourceStream(@"GifToSpriteMap.TestImage1.gif"))
			{
				Image image = imageExtractor.Extract(s, DestinationShape.Square);

				Assert.AreEqual(237, image.Width);
				Assert.AreEqual(252, image.Height);
			}
		}

		[Test]
		public void TestImage2()
		{
			var imageExtractor = new ImageExtractor();
			Assembly a = Assembly.GetExecutingAssembly();
			
			using (Stream s = a.GetManifestResourceStream(@"GifToSpriteMap.TestImage2.gif"))
			{
				Image i = imageExtractor.Extract(s, DestinationShape.Square);
				Assert.AreEqual(84, i.Width);
				Assert.AreEqual(123, i.Height);
			}
		}

		[Test]
		public void TestImage2WithProgress()
		{
			var imageExtractor = new ImageExtractor();
			imageExtractor.Progress += onExtractionProgress;
			Assembly assembly = Assembly.GetExecutingAssembly();
			using (Stream s = assembly.GetManifestResourceStream(@"GifToSpriteMap.TestImage2.gif"))
			{
				Image image = imageExtractor.Extract(s, DestinationShape.Square);
				Assert.AreEqual(84, image.Width);
				Assert.AreEqual(123, image.Height);
			}
		}

		static void onExtractionProgress(object sender, ProgressArgs args)
		{
			Image i = args.Image;
		}
	}
}
