﻿using System.Drawing ;

namespace NGif
{
	public class GifFrame
	{
		public GifFrame(Image im, int del)
		{
			image = im;
			delay = del;
		}
		public Image image;
		public int delay;
	}
}