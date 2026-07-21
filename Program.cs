using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Server;

var builder = Host.CreateApplicationBuilder(args);
builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();

await builder.Build().RunAsync();

public record BigIntResult(
    long Int64Max,
    long UnsafeButNotMax,
    long SafeIntegerMax);

[McpServerToolType]
public static class BigNumberTool
{
    [McpServerTool(Name = "return_big_numbers", UseStructuredContent = true, ReadOnly = true)]
    [Description("Returns 64-bit values using MCP structuredContent.")]
    public static BigIntResult ReturnBigNumbers()
    {
        return new BigIntResult(
            Int64Max: long.MaxValue,
            UnsafeButNotMax: 9_223_372_036_854_775L,
            SafeIntegerMax: 9_007_199_254_740_991L
        );
    }
}
