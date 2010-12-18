using System.Drawing ;

namespace GifToSpriteMap
{
	public class Frame
	{
		readonly Size _size;
		readonly Image _image;

		public Size Size
		{
			get { return _size; }
		}

		public Frame(Size size, Image image)
		{
			_size = size;
			_image = image;
		}

		public Image Image
		{
			get { return _image; }
		}
	}
}