using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Tao.DevIl;

namespace GifToSpriteMap
{
	public partial class ProcessingWindow : Form
	{
		readonly string[] _paths;
		readonly DestinationShape _destinationShape;
		readonly OutputFormat _outputFormat;

		Label _labelSource;
		Label _labelDest;

		public ProcessingWindow(string[] pathsOfFilesToProcess, DestinationShape destinationShape, OutputFormat outputFormat)
		{
			InitializeComponent();
			_paths = pathsOfFilesToProcess;
			_destinationShape = destinationShape;
			_outputFormat = outputFormat;
		}

		void onLoad(object sender, EventArgs e)
		{
			toolStripSplitButton1.Image = SystemIcons.Hand.ToBitmap();
			MinimumSize = Size;

			toolStripProgressBar1.Minimum = 0;
			toolStripProgressBar1.Maximum = _paths.Length;

			_labelSource = new Label
							{
								AutoSize = true,
								Text = @"Source image"
							};

			Controls.Add(_labelSource);

			_labelDest = new Label
							{
								AutoSize = true,
								Text = @"Current frame"
							};
			Controls.Add(_labelDest);

			adjustControlPlacement();

			ThreadPool.QueueUserWorkItem(workerThreadProc);
		}

		void adjustControlPlacement()
		{
			_labelDest.BringToFront();
			_labelSource.BringToFront();

			int halfHeight = Height / 2;

			pictureBoxSource.SetBounds(0, 0, this.Width, halfHeight);
			pictureBoxDestination.SetBounds(0, halfHeight, this.Width, halfHeight);

			_labelSource.Location = new Point(
			  Width / 2 - _labelSource.Width / 2,
			  pictureBoxSource.Height / 2 - _labelSource.Height / 2);

			_labelDest.Location = new Point(
			  Width / 2 - _labelDest.Width / 2,
			  pictureBoxDestination.Location.Y + (pictureBoxDestination.Height / 2 - _labelSource.Height / 2));
		}

		void workerThreadProc(object state)
		{
			var imageExtractor = new ImageExtractor();
			imageExtractor.Progress += onProgress;

			Image image = imageExtractor.Extract(_paths, _destinationShape);

			if (_outputFormat == OutputFormat.Bitmap)
			{
				saveAndShowPng(image);


			}
			else if (_outputFormat == OutputFormat.Dds)
			{
				saveAndShowDds(image);
			}
		}

		void saveAndShowPng(Image image)
		{
			string path = Path.GetTempFileName();
			path = path + @".png";

			image.Save(path);

			Process.Start(path);

			onProgress(this,
				new ProgressArgs(
					ProgressEvent.FinishedProcessingDestinationImage,
					@"Finished",
					null));
		}

		void saveAndShowDds(Image image)
		{
			string outputPath = Path.GetTempFileName() + @".png";
			string outputPathToDds = Path.GetTempFileName() + @".dds";

			image.Save(outputPath);

			int num;

			if (((Il.ilGetInteger(0xde2) < 0xa7) || (Il.ilGetInteger(0xde2) < 0xa1)) || (Il.ilGetInteger(0xde2) < 0xa7))
			{
				throw new InvalidOperationException(
					string.Format(
						@"
				Your DevIL native libraries are older than what Tao.DevIl supports, get the latest DevIL native libraries. ***
				Your DevIL native IL version: {0}.  Tao.DevIl's IL version: {1}.
				Your DevIL native ILU version: {2}.  Tao.DevIl's ILU version: {3}.
				Your DevIL native ILUT version: {4}.  Tao.DevIl's ILUT version: {5}.",
						Il.ilGetInteger(0xde2),
						0xa7,
						Il.ilGetInteger(0xde2),
						0xde2,
						Il.ilGetInteger(0xde2),
						0xde2));
			}

			Il.ilInit();
			Il.ilGenImages(1, out num);
			Il.ilBindImage(num);
			if (!Il.ilLoadImage(outputPath))
			{
				throw new InvalidOperationException(@"could not open the image file provided.");
			}

			Console.WriteLine("Width: {0} Height: {1}, Depth: {2}, Bpp: {3}", new object[] { Il.ilGetInteger(0xde4), Il.ilGetInteger(0xde5), Il.ilGetInteger(0xde6), Il.ilGetInteger(0xde9) });

			Il.ilEnable(0x620);
			Il.ilSaveImage(outputPathToDds);
			Il.ilDeleteImages(1, ref num);

			Process.Start(outputPathToDds);

			onProgress(this,
				new ProgressArgs(
					ProgressEvent.FinishedProcessingDestinationImage,
					@"Finished",
					null));
		}

		void onProgress(object sender, ProgressArgs args)
		{
			if (InvokeRequired)
			{
				BeginInvoke(new ImageExtractionHandler(onProgress), sender, args);
				return;
			}

			toolStripStatusLabel1.Text = args.Message;
			_labelDest.Text = args.Message;
			adjustControlPlacement();

			if (args.ProgressEvent == ProgressEvent.FinishedProcessingDestinationImage)
			{
				Close();
			}

			if (args.ProgressEvent == ProgressEvent.StartingToProcessSourceImage)
			{
				pictureBoxSource.Image = args.Image;
				toolStripProgressBar1.Increment(1);
			}
			if (args.ProgressEvent == ProgressEvent.StartingToProcessFrameFromSourceImage)
			{
				pictureBoxDestination.Image = args.Image;
			}
		}

		private void ProcessingWindow_SizeChanged(object sender, EventArgs e)
		{
			adjustControlPlacement();
		}

		private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}