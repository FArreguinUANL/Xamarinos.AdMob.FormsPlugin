using Xamarinos.AdMob.Forms.Abstractions;
using System;
using Xamarin.Forms;
using Xamarinos.AdMob.Forms.Android;
using Xamarin.Forms.Platform.Android;
using Android.Gms.Ads;
using System.Collections.Generic;

[assembly: ExportRenderer(typeof(Xamarinos.AdMob.Forms.AdBanner), typeof(Xamarinos.AdMob.Forms.Android.AdBannerRenderer))]
namespace Xamarinos.AdMob.Forms.Android
{
    public class AdBannerRenderer : ViewRenderer
    {
        static string[] _TestDevices = new string[] { };

        public AdBannerRenderer()
        {
        }

        public static void Init(params string[] testDevices)
        {
            _TestDevices = testDevices;
            var debug = true;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                var adsbanner = (AdBanner)Element;
                var adview = new AdView(Context);
                adview.AdSize = AdSize.Banner;
                adview.AdUnitId = adsbanner.AdID;
                var requestbuilder = new AdRequest.Builder().AddTestDevice(AdRequest.DeviceIdEmulator);
                if (_TestDevices?.Length >0)
                {
                    foreach(string thisTestDevice in _TestDevices)
                    {
                        requestbuilder.AddTestDevice(thisTestDevice);
                    }
                }
                
                adview.LoadAd(requestbuilder.Build());
                base.SetNativeControl(adview);
            }

        }
    }
}