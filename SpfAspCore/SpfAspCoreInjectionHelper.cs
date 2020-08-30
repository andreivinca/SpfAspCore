using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SpfAspCore.Extensions;
using SPFSpfAspCoreJSASPCORE.SPFBuilder;

namespace SpfAspCore
{
    public static class SPFASPCOREInjectionHelper
    {
        /// <summary>
        /// Adds Live Reload WebSocket script into the page before the body tag.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <param name="context"></param>
        /// <param name="baseStream">The raw Response Stream</param>
        /// <returns></returns>
        public static Task InjectSpfCoreAsync(byte[] buffer, int offset, int count, HttpContext context, Stream baseStream)
        {
            Span<byte> currentBuffer = buffer;
            var curBuffer = currentBuffer.Slice(offset, count).ToArray();
            return InjectLiveReloadScriptAsync(curBuffer, context, baseStream);
        }

        /// <summary>
        /// Adds Live Reload WebSocket script into the page before the body tag.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="context"></param>
        /// <param name="baseStream">The raw Response Stream</param>
        /// <returns></returns>
        public static async Task InjectLiveReloadScriptAsync(byte[] buffer, HttpContext context, Stream baseStream)
        {
            var stream = new MemoryStream(buffer, 0, buffer.Length);
            if (!context.IsSPFRequest())
            {
                await baseStream.WriteAsync(buffer, 0, buffer.Length);
                return; 
            }

            var builder = new SpfAspCoreResponseBuilder(stream);
            var newBuffer = builder.Build();
            await baseStream.WriteAsync(newBuffer, 0, newBuffer.Length);
        }
    }
}
