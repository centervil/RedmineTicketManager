// <copyright file="IIssueFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

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
        BaseIssueEx Create(DataRow source);
    }
}
