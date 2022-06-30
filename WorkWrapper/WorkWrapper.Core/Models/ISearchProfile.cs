namespace WorkWrapper.Core.Models;

public interface ISearchProfile : IBaseProfile
{
    DateTime? Custom21From { get; }
    DateTime? Custom21To { get; }
    DateTime? Custom22From { get; }
    DateTime? Custom22To { get; }
    DateTime? Custom23From { get; }
    DateTime? Custom23To { get; }
    DateTime? Custom24From { get; }
    DateTime? Custom24To { get; }
    /// <summary>
    /// Pattern: ^(([-+]?\d+)([dDwWmMyY])?(:([-+]?(\d+)))([dDwWmMyY]))|(([-+]?\d+)([dDwWmMyY])(:([-+]?(\d+)))([dDwWmMyY])?)|^([-+]?\d+[dDwWmMyY])$
    /// </summary>
    string? Custom21Relative { get; }
    /// <summary>
    /// Pattern: ^(([-+]?\d+)([dDwWmMyY])?(:([-+]?(\d+)))([dDwWmMyY]))|(([-+]?\d+)([dDwWmMyY])(:([-+]?(\d+)))([dDwWmMyY])?)|^([-+]?\d+[dDwWmMyY])$
    /// </summary>
    string? Custom22Relative { get; }
    /// <summary>
    /// Pattern: ^(([-+]?\d+)([dDwWmMyY])?(:([-+]?(\d+)))([dDwWmMyY]))|(([-+]?\d+)([dDwWmMyY])(:([-+]?(\d+)))([dDwWmMyY])?)|^([-+]?\d+[dDwWmMyY])$
    /// </summary>
    string? Custom23Relative { get; }
    /// <summary>
    /// Pattern: ^(([-+]?\d+)([dDwWmMyY])?(:([-+]?(\d+)))([dDwWmMyY]))|(([-+]?\d+)([dDwWmMyY])(:([-+]?(\d+)))([dDwWmMyY])?)|^([-+]?\d+[dDwWmMyY])$
    /// </summary>
    string? Custom24Relative { get; }
}