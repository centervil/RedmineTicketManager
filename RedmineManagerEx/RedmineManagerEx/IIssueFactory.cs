using System.Data;

namespace RedmineManagerEx
{
    /// <summary>
    /// IIssueExの実体を生成するクラスのInterface
    /// </summary>
    public interface IIssueFactory
    {
        /// <summary>
        /// IIssueExインスタンスの生成
        /// </summary>
        /// <param name="source"></param>
        /// <returns>IIssueEx</returns>
        IIssueEx Create(DataRow source);
    }
}
