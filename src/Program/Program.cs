using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using TwitterUCU;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Parte 1 y 2
            
            PictureProvider p = new PictureProvider();
            IPicture picture = p.GetPicture(@".\luke.jpg");
            IPicture picture2 = p.GetPicture(@".\luke.jpg");
            IPicture pictureFinal = p.GetPicture(@".\luke.jpg");

            IFilter fn = new FilterNegative();
            IFilter fg = new FilterGreyscale();
            IFilter fbc = new FilterBlurConvolution();

            /*
            IPipe pn3 = new PipeNull();
            IPipe ps3 = new PipeSerial(fg,pn3);
            IPipe pn2 = new PipeNull();
            IPipe pn = new PipeNull();
            IPipe pf2 = new PipeFork(ps3,pn2);
            IPipe ps2 = new PipeSerial(fn,pf2);
            IPipe pf = new PipeFork(ps2,pn);
            IPipe ps = new PipeSerial(fg,pf);
            

            IPicture primerLuke = pf.Send(picture);
            IPicture segundoLuke = pf2.Send(picture2);
            IPicture lukeFinal = ps.Send(pictureFinal);

            
            p.SavePicture(primerLuke,@"luke1.jpg");
            p.SavePicture(segundoLuke,@"luke2.jpg");
            p.SavePicture(lukeFinal, @".\lukeFinal.jpg");
            */
            #endregion

            #region Parte 3
            // var twitter = new TwitterImage();
            // Console.WriteLine(twitter.PublishToTwitter("test", @"lukeFinal.jpg"));
            #endregion
            
            #region Parte 4

            IPipe pn2 = new PipeNull();
            IPipe pn = new PipeNull();
            IPipe ps2 = new PipeSerial(fg,pn2);
            IPipe ps = new PipeSerial(fn,pn);
            IPipe pcf = new PipeConditionalFork(ps,ps2);

            PictureProvider provider = new PictureProvider();
            IPicture pic = provider.GetPicture(@"beer.jpg");

            IPicture res = pcf.Send(pic);

            provider.SavePicture(res,@"resultado.jpg");

            #endregion
        }
    }
}
