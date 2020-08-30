using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

#if !NETCORE2
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Hosting;
#endif

namespace SpfAspCore
{
    public class SpfAspCoreMiddleware
    {
        private readonly RequestDelegate _next;

#if !NETCORE2
        private IHostApplicationLifetime applicationLifetime = null;
        public SpfAspCoreMiddleware(RequestDelegate next, IHostApplicationLifetime lifeTime)
        {
            applicationLifetime = lifeTime;
            _next = next;
        }
#else
            private IApplicationLifetime applicationLifetime = null;

            public SpfAspCoreMiddleware(RequestDelegate next, IApplicationLifetime lifeTime)
            {
                _next = next;
            }
#endif


        /// <summary>
        /// Routes to WebSocket handler and injects javascript into
        /// HTML content
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>

        public async Task InvokeAsync(HttpContext context)
        {
            var config = SpfAspCoreConfiguration.Current;
            if (!config.SpfAspCoreEnabled)
            {
                await _next(context);
                return;
            }

            // Check other content for HTML
            await HandleHtmlInjection(context);
        }

        /// <summary>
        /// Inspects all non WebSocket content for HTML documents
        /// and if it finds HTML injects the JavaScript needed to
        /// refresh the browser via Web Sockets.
        ///
        /// Uses a wrapper stream to wrap the response and examine
        /// only text/html requests - other content is passed through
        /// as is.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async Task HandleHtmlInjection(HttpContext context)
        {
            var path = context.Request.Path.Value;

            // Use a custom StreamWrapper to rewrite output on Write/WriteAsync
            using (var filteredResponse = new ResponseStreamWrapper(context.Response.Body, context))
            {
#if !NETCORE2
                // Use new IHttpResponseBodyFeature for abstractions of pilelines/streams etc.
                // For 3.x this works reliably while direct Response.Body was causing random HTTP failures
                context.Features.Set<IHttpResponseBodyFeature>(new StreamResponseBodyFeature(filteredResponse));
#else
                context.Response.Body = filteredResponse;
#endif

                await _next(context);
            }

        }
    }
}