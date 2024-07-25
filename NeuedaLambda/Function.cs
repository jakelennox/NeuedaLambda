using Amazon.Lambda.Core;
using static Amazon.Lambda.SQSEvents.SQSEvent;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace NeuedaLambda;

public class Function
{
    /// <summary>
    /// Function to log a <see cref="SQSMessage"/>
    /// </summary>
    /// <param name="sqsMessage">The sqs message to log.</param>
    /// <param name="context">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
    /// <returns></returns>
    public bool FunctionHandler(SQSMessage sqsMessage, ILambdaContext context)
    {
        try
        {
            context.Logger.Log($"[{DateTime.UtcNow}] SQS message: {sqsMessage.Body}");
            return true;
        }
        catch (Exception ex)
        {
            context.Logger.LogError($"[{DateTime.UtcNow}] Error: {ex.Message}");
            return false;
        }
    }
}