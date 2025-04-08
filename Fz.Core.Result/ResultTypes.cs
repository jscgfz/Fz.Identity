using Fz.Core.Result.Common;

namespace Fz.Core.Result;

public static class ResultTypes
{
  public static ResultType Continue => new(100, " Continue ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.2.1");
  public static ResultType SwitchingProtocols => new(101, " Switching Protocols ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.2.2");
  public static ResultType OK => new(200, " OK ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.3.1");
  public static ResultType Created => new(201, " Created ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.3.2");
  public static ResultType Accepted => new(202, " Accepted ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.3.3");
  public static ResultType NonAuthoritativeInformation => new(203, " Non-Authoritative Information ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.3.4");
  public static ResultType NoContent => new(204, " No Content ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.3.5");
  public static ResultType ResetContent => new(205, " Reset Content ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.3.6");
  public static ResultType PartialContent => new(206, " Partial Content ", "https://datatracker.ietf.org/doc/html/rfc7233#section-4.1");
  public static ResultType MultipleChoices => new(300, " Multiple Choices ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.4.1");
  public static ResultType MovedPermanently => new(301, " Moved Permanently ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.4.2");
  public static ResultType Found => new(302, " Found ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.4.3");
  public static ResultType SeeOther => new(303, " See Other ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.4.4");
  public static ResultType NotModified => new(304, " Not Modified ", "https://datatracker.ietf.org/doc/html/rfc7232#section-4.1");
  public static ResultType UseProxy => new(305, " Use Proxy ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.4.5");
  public static ResultType TemporaryRedirect => new(307, " Temporary Redirect ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.4.7");
  public static ResultType BadRequest => new(400, " Bad Request ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1");
  public static ResultType ValidationError => new(400, " Bad Request ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1");
  public static ResultType Unauthorized => new(401, " Unauthorized ", "https://datatracker.ietf.org/doc/html/rfc7235#section-3.1");
  public static ResultType PaymentRequired => new(402, " Payment Required ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.2");
  public static ResultType Forbidden => new(403, " Forbidden ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.3");
  public static ResultType NotFound => new(404, " Not Found ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4");
  public static ResultType MethodNotAllowed => new(405, " Method Not Allowed ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.5");
  public static ResultType NotAcceptable => new(406, " Not Acceptable ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.6");
  public static ResultType ProxyAuthenticationRequired => new(407, " Proxy Authentication Required ", "https://datatracker.ietf.org/doc/html/rfc7235#section-3.2");
  public static ResultType RequestTimeout => new(408, " Request Timeout ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.7");
  public static ResultType Conflict => new(409, " Conflict ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8");
  public static ResultType Gone => new(410, " Gone ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.9");
  public static ResultType LengthRequired => new(411, " Length Required ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.10");
  public static ResultType PreconditionFailed => new(412, " Precondition Failed ", "https://datatracker.ietf.org/doc/html/rfc7232#section-4.2");
  public static ResultType PayloadTooLarge => new(413, " Payload Too Large ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.11");
  public static ResultType URITooLong => new(414, " URI Too Long ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.12");
  public static ResultType UnsupportedMediaType => new(415, " Unsupported Media Type ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.13");
  public static ResultType RangeNotSatisfiable => new(416, " Range Not Satisfiable ", "https://datatracker.ietf.org/doc/html/rfc7233#section-4.4");
  public static ResultType ExpectationFailed => new(417, " Expectation Failed ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.14");
  public static ResultType UpgradeRequired => new(426, " Upgrade Required ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.15");
  public static ResultType InternalServerError => new(500, " Internal Server Error ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1");
  public static ResultType UnhandledError => new(500, " Internal Server Error ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1");
  public static ResultType NotImplemented => new(501, " Not Implemented ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.2");
  public static ResultType BadGateway => new(502, " Bad Gateway ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.3");
  public static ResultType ServiceUnavailable => new(503, " Service Unavailable ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.4");
  public static ResultType GatewayTimeout => new(504, " Gateway Timeout ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.5");
  public static ResultType HTTPVersionNotSupported => new(505, " HTTP Version Not Supported ", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.6");
  public static bool IsSuccess(ResultType type) => !UnsuccessTypes.Contains(type.Status);
  public static bool IsValidType(ResultType type) => type.Status is > 99 and < 600;

  private static readonly IEnumerable<int> UnsuccessTypes = [ 400 ,401 ,402 ,403 ,404 ,405 ,406 ,407 ,408 ,409 ,410 ,411 ,412 ,413 ,414 ,415 ,416 ,417 ,426 ,500 ,501 ,502 ,503 ,504 ,505 ];
}
