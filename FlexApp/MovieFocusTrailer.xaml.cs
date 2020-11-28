using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TMDbLib;

namespace FlexApp
{
    /// <summary>
    /// Interaction logic for MovieFocusTrailer.xaml
    /// </summary>
    public partial class MovieFocusTrailer : UserControl
    {

        // Färska Trailer Links
        //  | | | | | | | | |
        //  V V V V V V V V V
        // https://imdb-api.com/API/YouTube/k_6f3w3pvw/8hP9D6kZseM
        // -------------------------
        // --> Copy Pasta + .mp4 <--
        // -------------------------
          //                       \\
        string[] TrailerUrl = new string[] { "https://www.imdb.com/video/vi2525675801?ref_=vi_tr_tr_vp_0.mp4",
            "https://r2---sn-4g5ednss.googlevideo.com/videoplayback?expire=1606531734&ei=NmbBX9zbIJSp1wLtnavABw&ip=5.9.146.174&id=o-AEU-_oWkQ9Y21msUDsSqqsOfulhCB_1Sfc4b18stRvUx&itag=22&source=youtube&requiressl=yes&mh=1C&mm=31%2C29&mn=sn-4g5ednss%2Csn-4g5e6ne6&ms=au%2Crdu&mv=u&mvi=2&pl=21&vprv=1&mime=video%2Fmp4&ns=XKpHIjVAiASYy8ZAC3dbxmkF&ratebypass=yes&dur=83.150&lmt=1507253603506620&mt=1606509466&fvip=2&c=WEB&n=qapJQiU32z_BfGZg9dw&sparams=expire%2Cei%2Cip%2Cid%2Citag%2Csource%2Crequiressl%2Cvprv%2Cmime%2Cns%2Cratebypass%2Cdur%2Clmt&sig=AOq0QJ8wRQIgHEY8UW6tJuQ1IuKtUxmdI381T6eOb4l9dzECQupRmjMCIQDToXcHgG4QWTQW1sgfiOiz13n0Sme9i_GSK8r8fnPrmg%3D%3D&lsparams=mh%2Cmm%2Cmn%2Cms%2Cmv%2Cmvi%2Cpl&lsig=AG3C_xAwRQIhALtLrkkEqpPRmARz18R3m_5sAGFFw2A0U5YzpEJB71chAiBHSvhp_ia5UqwXUmSGAImoTHw7gse2US2BwYBxPxY2zA%3D%3D&title=Inception+-+Official+Trailer+[HD].mp4",
            "https://r5---sn-4g5ednsk.googlevideo.com/videoplayback?expire=1606505280&ei=3_7AX-DaNtPt-gbehqmYDg&ip=5.9.146.174&id=o-AD1RElWxUXBgpFkod9BqKgxNXFi5EHahSLJ8zi3Rd-Pj&itag=22&source=youtube&requiressl=yes&mh=sO&mm=31%2C29&mn=sn-4g5ednsk%2Csn-4g5e6ns6&ms=au%2Crdu&mv=u&mvi=5&pl=21&vprv=1&mime=video%2Fmp4&ns=2uA5V0gu6zDzhTFgAmr40jQF&ratebypass=yes&dur=187.199&lmt=1537242292391344&mt=1606483453&fvip=5&c=WEB&n=j9L_42a3xiu1w9i0mgk&sparams=expire%2Cei%2Cip%2Cid%2Citag%2Csource%2Crequiressl%2Cvprv%2Cmime%2Cns%2Cratebypass%2Cdur%2Clmt&sig=AOq0QJ8wRAIgcavBzsQYlrqMtP9TQBQLwhPaKUC85HGq1VDU9EUVxUECIA08Fxg89iUPsnBxefb13AJjH8otb6J_pmuOupd6Kl4c&lsparams=mh%2Cmm%2Cmn%2Cms%2Cmv%2Cmvi%2Cpl&lsig=AG3C_xAwRQIhAPGN9vB-EHME2x2d4dnn4l71iJJxbp3zoN1lX2gaoFcaAiAP6DFg9tc1fTRvGLelZ4oj6Pwqo4D48CXTrRB7Lwjpww%3D%3D&title=Toy+Story+Trailer+1995++Disney+Throwback++Oh+My+Disney.mp4",
            "https://r2---sn-4g5e6ne6.googlevideo.com/videoplayback?expire=1606504965&ei=pf3AX8W_F7OFx_APk5ugyA8&ip=5.9.146.174&id=o-AGrgnjieBugHy7pne-1hVzYKMGdoXGnWqvnfYaCaBznM&itag=18&source=youtube&requiressl=yes&mh=1C&mm=31%2C26&mn=sn-4g5e6ne6%2Csn-f5f7ln7y&ms=au%2Conr&mv=m&mvi=2&pl=21&initcwndbps=480000&vprv=1&mime=video%2Fmp4&ns=Je4b393A2mWG9mmnEU93RJMF&gir=yes&clen=5016748&ratebypass=yes&dur=83.150&lmt=1416917420476214&mt=1606482998&fvip=2&c=WEB&n=G-JsK7ZgQHahUNiKGNx&sparams=expire%2Cei%2Cip%2Cid%2Citag%2Csource%2Crequiressl%2Cvprv%2Cmime%2Cns%2Cgir%2Cclen%2Cratebypass%2Cdur%2Clmt&sig=AOq0QJ8wRQIhAKkkZcFwD1UNeM76Og6P76PFXUYy-j-CLXYX0TMPbMDfAiBT3UzkMtD9KZJjwNFyrAWEd1fBxGwcDvdLzsSTxos2Pw%3D%3D&lsparams=mh%2Cmm%2Cmn%2Cms%2Cmv%2Cmvi%2Cpl%2Cinitcwndbps&lsig=AG3C_xAwRQIgYzGokUcGrJCUPD_RVYcwNhspw_t67rHVTy6ev2OICs0CIQDLrsl-dVd2juXDvnl1stqZdDX336cx6pFOitKOONr2kw%3D%3D&title=Inception+-+Official+Trailer+[HD].mp4" };
        public MovieFocusTrailer()
        {
            InitializeComponent();



            Trailer.Source = new Uri(TrailerUrl[0], UriKind.Absolute);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            Status.Content = "00:00 / 00:00";
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (Trailer.Source != null)
            {
                if (Trailer.NaturalDuration.HasTimeSpan)
                {
                    Status.Content = String.Format($"{Trailer.Position.ToString(@"mm\:ss")} / {Trailer.NaturalDuration.TimeSpan.ToString(@"mm\:ss")}");
                }
            }
            else
            {
                Status.Content = Helper.Message.TrailerErrorLoading;
            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            Trailer.Stop();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            Trailer.Play();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            Trailer.Pause();
        }
    }
}
