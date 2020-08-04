using System.ComponentModel;

namespace ModelService
{
    public enum ApiResponseCode
    {
        [Description("Thành công")]
        Success = 0, 
        [Description("Thất bại")]
        Failed = 1 
    }
    
}
