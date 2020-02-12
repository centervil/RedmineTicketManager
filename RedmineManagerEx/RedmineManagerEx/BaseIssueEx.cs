// <copyright file="BaseIssueEx.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RedmineManagerEx
{
    /// <summary>
    /// IssueExの基底クラス
    /// </summary>
    public abstract class BaseIssueEx
    {
        /// <summary>
        /// Gets title
        /// </summary>
        public virtual string Title { get; }

        /// <summary>
        /// Gets projectID
        /// </summary>
        public virtual int IssueID { get; }
    }
}