using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveWebContent
{
	public class CustomResourceRequestHandler : CefSharp.Handler.ResourceRequestHandler
	{
		protected override IResourceHandler GetResourceHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request)
		{
			//ResourceHandler has many static methods for dealing with Streams, 
			// byte[], files on disk, strings
			// Alternatively ou can inheir from IResourceHandler and implement
			// a custom behaviour that suites your requirements.
			return ResourceHandler.FromFilePath(@"E:\Download\void.png");
		}

        protected override CefReturnValue OnBeforeResourceLoad(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback)
        {
			var headers = request.Headers;
			headers["Access-Control-Allow-Origin"] = "*";
			request.Headers = headers;

			return CefReturnValue.Continue;
		}
    }

	public class CustomRequestHandler : CefSharp.Handler.RequestHandler
	{
		protected override IResourceRequestHandler GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
		{
			//Only intercept specific Url's
			if (request.Url == "https://webstatic.hoyoverse.com/upload/event/2022/09/26/b242c62b24a0290f5253cd5b1962aefd_1450942664002734253.png")
			{
				return new CustomResourceRequestHandler();
			}

			//Default behaviour, url will be loaded normally.
			return null;
		}
	}

}
