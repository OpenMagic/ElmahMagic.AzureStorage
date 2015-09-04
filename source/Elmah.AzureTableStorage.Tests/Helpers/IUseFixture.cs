// Original source - https://github.com/techtalk/SpecFlow/issues/419#issuecomment-105622648
// ReSharper disable once CheckNamespace

namespace Xunit
{
    /// <summary>
    ///     XUnit backwards compatibility for feature generator
    /// </summary>
    /// <remarks>
    ///     Delete this when generator no longer uses this class - 5/25/15
    /// </remarks>
    public interface IUseFixture<T> : IClassFixture<T> where T : class, new()
    {
    }
}