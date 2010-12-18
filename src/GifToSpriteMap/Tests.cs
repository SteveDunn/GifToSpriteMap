using System;
using System.Collections.Generic;
using System.Drawing ;
using System.IO ;
using System.Reflection ;
using System.Text;
using MbUnit.Framework ;
//using NUnit.Framework ;

namespace GifToSpriteMap
{
  [TestFixture]
  public class Tests
  {
    [Test]
    public void TestCombinedImage( )
    {
      ImageExtractor ie = new ImageExtractor( ) ;
      Stream[ ] streams = new Stream[2] ;
      Assembly a = Assembly.GetExecutingAssembly( ) ;
      
      streams[ 0 ] = a.GetManifestResourceStream( @"GifToSpriteMap.TestImage1.gif" ) ;
      streams[ 1 ] = a.GetManifestResourceStream( @"GifToSpriteMap.TestImage2.gif" ) ;
      
      Image i = ie.Extract( streams, DestinationShape.Square ) ;
      Assert.AreEqual( 237, i.Width );
      Assert.AreEqual( 504, i.Height );
    }

    [Test]
    public void TestImage1( )
    {
      ImageExtractor ie = new ImageExtractor( ) ;
      Assembly a = Assembly.GetExecutingAssembly( ) ;
      using( 
        Stream s = a.GetManifestResourceStream( @"GifToSpriteMap.TestImage1.gif" ) )
      {
        Image i = ie.Extract( s, DestinationShape.Square ) ;

        Assert.AreEqual( 237, i.Width ) ;
        Assert.AreEqual( 252, i.Height ) ;
      }
    }
    
    [Test]
    public void TestImage2( )
    {
      ImageExtractor ie = new ImageExtractor( ) ;
      Assembly a = Assembly.GetExecutingAssembly( ) ;
      using( Stream s = a.GetManifestResourceStream( @"GifToSpriteMap.TestImage2.gif" )  )
      {
        Image i = ie.Extract( s, DestinationShape.Square ) ;
        Assert.AreEqual( 84, i.Width );
        Assert.AreEqual( 123, i.Height );
      }
    }

    [Test]
    public void TestImage2WithProgress( )
    {
      ImageExtractor ie = new ImageExtractor( ) ;
      ie.Progress += new ImageExtractionHandler(ie_Progress);
      Assembly a = Assembly.GetExecutingAssembly( ) ;
      using( Stream s = a.GetManifestResourceStream( @"GifToSpriteMap.TestImage2.gif" )  )
      {
        Image i = ie.Extract( s, DestinationShape.Square ) ;
        Assert.AreEqual( 84, i.Width );
        Assert.AreEqual( 123, i.Height );
      }
    }

    void ie_Progress(object sender, ProgressArgs args)
    {
      Image i = args.Image ;
      int n = 1 ;
      
    }

  
  }
}
