
namespace FxApp.Data
{
    public interface IAppMode
    {
        string ServiceBaseUrl { get; }
        string DbPath { get; set; }
    }
}
