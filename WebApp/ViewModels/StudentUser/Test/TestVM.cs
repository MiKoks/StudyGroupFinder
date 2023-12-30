using NuGet.Protocol.Plugins;
#pragma warning disable 1591
namespace WebApp.ViewModels.StudentUser.Test;

public class TestVM
{
    public BLL.DTO.Courses? Courses { get; set; }
    public TestVMLoading? TestVmLoading { get; set; }
    public TestVMUpdateData TestVmUpdateData { get; set; } = default!;
}

public class TestVMLoading
{
    public System.Collections.Generic.IEnumerable<BLL.DTO.Courses>? Courses { get; set; }
}

public class TestVMUpdateData
{
    public BLL.DTO.Courses Courses { get; set; } = default!;
}